using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using Accounting.Gardesh;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Notification;
using Payamak;
using Payamak.PhoneBook;
using Print;
using Services;
using Settings;
using User;

namespace Peoples
{
    public partial class frmShowPeoples : MetroForm
    {
        private Guid _groupGuid = Guid.Empty;
        public Guid GroupGuid { get => _groupGuid; set => _groupGuid = value; }
        public Guid SelectedGuid { get; set; }
        private bool isShowMode = false;
        private IEnumerable<PeoplesBussines> list;
        private bool _st = true;
        private List<string> ColumnList;
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task LoadGroupsAsync()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                groupBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name).ToList();
                trvGroup.Nodes.Clear();
                var lst = await PeopleGroupBussines.GetAllAsync();
                var node = new TreeNode { Text = "همه گروه ها", Name = Guid.Empty.ToString() };
                trvGroup.Nodes.Add(node);
                foreach (var item in lst.Where(q => q.ParentGuid == Guid.Empty && q.Status).OrderBy(q => q.Name).ToList())
                {
                    node = new TreeNode { Text = item.Name, Name = item.Guid.ToString() };
                    trvGroup.Nodes.Add(node);
                }

                lst = await PeopleGroupBussines.GetAllAsync();
                foreach (var item in lst.Where(q => q.ParentGuid != Guid.Empty && q.Status).OrderBy(q => q.Name).ToList())
                {
                    foreach (TreeNode n in trvGroup.Nodes)
                    {
                        if (item.ParentGuid.ToString() != n.Name) continue;
                        node = new TreeNode { Text = item.Name, Name = item.Guid.ToString() };
                        n.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadPeoplesAsync(string search = "")
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                list = await PeoplesBussines.GetAllAsync(search, GroupGuid, _token.Token);
                dgGroupName.Visible = GroupGuid == Guid.Empty;
                _ = Task.Run(() => ucPagger.PagingAsync(new CancellationToken(),
                    list?.Where(q => q.Status == _st), 100, PagingPosition.GotoStartPage));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetAccess()
        {
            try
            {
                var access = UserBussines.CurrentUser.UserAccess;
                mnuAdd.Enabled = access?.Peoples.People_Insert ?? false;
                mnuEdit.Enabled = access?.Peoples.People_Update ?? false;
                mnuDelete.Enabled = access?.Peoples.People_Delete ?? false;
                mnuView.Enabled = access?.Peoples.People_View ?? false;
                mnuBank.Enabled = access?.Peoples.People_Show_BankHesab ?? false;
                mnuDelGroup.Enabled = access?.Peoples.People_Group_Delete ?? false;
                mnuInsGroup.Enabled = access?.Peoples.People_Group_Insert ?? false;
                mnuIpmortFromExcel.Enabled = access?.Peoples.People_Import_Excel ?? false;
                mnuSendSMS.Enabled = access?.Peoples.People_SendSms ?? false;
                mnuUpGroup.Enabled = access?.Peoples.People_Group_Update ?? false;
                mnuTell.Enabled = access?.Peoples.People_Show_Tell ?? false;
                mnuPrint.Enabled = access?.Peoples.People_Print ?? false;
                mnuIpmortFromExcel.Visible = VersionAccess.Excel;
                dgServerStatusImage.Visible = VersionAccess.WebService;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void LoadData()
        {
            try
            {
                await LoadGroupsAsync();
                await LoadPeoplesAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Select()
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                SelectedGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowPeoples(bool _isShowMode, bool status = true)
        {
            InitializeComponent();
            isShowMode = _isShowMode;
            _st = status;
            ucHeader.Text = "نمایش لیست اشخاص";
            if (isShowMode)
            {
                contextMenu.Enabled = false;
                contextMenuGroup.Enabled = false;
            }
            else
            {
                contextMenu.Enabled = true;
                contextMenuGroup.Enabled = true;
            }
            ucPagger.OnBindDataReady += UcPagger_OnBindDataReady;
            SetAccess();
        }

        private async void UcPagger_OnBindDataReady(object sender, WindowsSerivces.Pagging.FooterBindingDataReadyEventArg e)
        {
            try
            {
                var count = e?.ListData?.Count ?? 0;
                if (count <= 0) count = 50;
                while (!IsHandleCreated) await Task.Delay(100);
                Invoke(new MethodInvoker(() => peopleBindingSource.DataSource = e?.ListData?.Take(count)?.ToSortableBindingList()));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmShowPeoples_Load(object sender, EventArgs e) => LoadData();
        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["dgRadif"].Value = e.RowIndex + 1;
        }
        private void frmShowPeoples_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F12:
                        mnuView.PerformClick();
                        break;
                    case Keys.Escape:
                        if (!string.IsNullOrEmpty(txtSearch.Text))
                        {
                            txtSearch.Text = "";
                            return;
                        }
                        Close();
                        break;
                    case Keys.Down:
                        if (txtSearch.Focused)
                            DGrid.Focus();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Enter:
                        if (!isShowMode) mnuEdit.PerformClick();
                        else Select();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void trvGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                var node = trvGroup.SelectedNode;
                if (node.Text == "همه گروه ها")
                    GroupGuid = Guid.Empty;
                else
                {
                    var group = await PeopleGroupBussines.GetAsync(Guid.Parse(node.Name));
                    if (group != null)
                        GroupGuid = group.Guid;
                }
                await LoadPeoplesAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void txtSearch_TextChanged(object sender, EventArgs e) => await LoadPeoplesAsync(txtSearch.Text);
        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                Select();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeopleMain(new PeoplesBussines(), false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadPeoplesAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmSetPrintSize();
                if (frm.ShowDialog(this) != DialogResult.OK) return;

                if (frm._PrintType != EnPrintType.Excel)
                {
                    var cls = new ReportGenerator(StiType.People_List, frm._PrintType) { Lst = new List<object>(list) };
                    cls.PrintNew();
                    return;
                }

                ExportToExcel.Export(list, this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuIpmortFromExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmImportExcel();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    LoadData();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var pe = await PhoneBookBussines.GetAllAsync(guid, true);

                var frm = new frmSendSms(pe.Select(q => q.Tell).ToList(), guid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await PeoplesBussines.GetAsync(guid, null);
                if (obj == null) return;
                var frm = new frmPeoplesBankAccount(obj);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuTell_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmShowPhoneBook(guid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuDelGroup_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (trvGroup.SelectedNode == null) return;
                if (trvGroup.SelectedNode.Text == "همه گروه ها") return;

                var counter = await PeopleGroupBussines.ChildCountAsync(GroupGuid);
                if (counter > 0)
                {
                    res.AddError(
                        $"گروه {trvGroup.SelectedNode.Text} بدلیل داشتن {counter} زیرگروه فعال، قادر به حذف نیست");
                }
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var childes = await PeoplesBussines.GetAllAsync(GroupGuid, true, _token.Token);
                if (childes != null && childes.Count > 0)
                {
                    res.AddError(
                        $"گروه {trvGroup.SelectedNode.Text} بدلیل داشتن {childes.Count} شخص فعال، قادر به حذف نیست");
                }

                if (res.HasError) return;
                if (MessageBox.Show(this, $@"آیا از حذف گروه {trvGroup.SelectedNode.Text} اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                var group = await PeopleGroupBussines.GetAsync(GroupGuid);
                res.AddReturnedValue(await group.ChangeStatusAsync(false));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در حذف گروه اشخاص");
                else await LoadGroupsAsync();
            }
        }
        private async void mnuUpGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvGroup.SelectedNode == null) return;
                if (trvGroup.SelectedNode.Text == "همه گروه ها") return;
                var obj = await PeopleGroupBussines.GetAsync(GroupGuid);
                if (obj == null) return;
                var frm = new frmPropleGroup(obj);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuInsGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPropleGroup(new PeopleGroupBussines());
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuDelete_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (_st)
                {
                    var p = await PeoplesBussines.GetAsync(guid, null);
                    if (p == null) return;
                    if (p.Account != 0)
                    {
                        res.AddError("به دلیل داشتن گردش حساب، شما مجاز به حذف شخص نمی باشید");
                        return;
                    }

                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PeoplesBussines.GetAsync(guid, null);
                    res.AddReturnedValue(await prd.ChangeStatusAsync(false));
                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟",
                            "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PeoplesBussines.GetAsync(guid, null);

                    if (prd.GroupGuid == Guid.Empty)
                    {
                        var frm = new frmChangeGroup(prd);
                        if (frm.ShowDialog(this) != DialogResult.OK) return;
                    }

                    res.AddReturnedValue(await prd.ChangeStatusAsync(true));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در تغییر وضعیت شخص");
                else await LoadPeoplesAsync(txtSearch.Text);
            }
        }
        private async void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await PeoplesBussines.GetAsync(guid, null);
                if (obj == null) return;
                var frm = new frmPeopleMain(obj, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async void mnuEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!_st)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var obj = await PeoplesBussines.GetAsync(guid, null);
                if (obj == null) return;
                var frm = new frmPeopleMain(obj, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadPeoplesAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGrid_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (peopleBindingSource.Count <= 0 || peopleBindingSource.Count == ucPagger.list.Count)
                    return;
                var addedItem = 0;
                var percent = 100 * (double)e.NewValue / peopleBindingSource.Count;
                if (percent <= 70) return;
                foreach (var item in ucPagger.NextItemsInPage(peopleBindingSource.Count, 50))
                {
                    peopleBindingSource.Add(item);
                    addedItem++;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void mnuGardesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var tafsilGuid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmGardeshTafsil(tafsilGuid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
