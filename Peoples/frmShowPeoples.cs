using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Notification;
using Payamak;
using Payamak.PhoneBook;
using Print;
using Services;
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
        public bool ST
        {
            get => _st;
            set
            {
                _st = value;
                if (_st)
                {
                    btnChangeStatus.Text = "غیرفعال (Ctrl+S)";
                    Task.Run(() => LoadPeoplesAsync(ST, txtSearch.Text));
                    btnDelete.Text = "حذف (Del)";
                }
                else
                {
                    btnChangeStatus.Text = "فعال (Ctrl+S)";
                    Task.Run(() => LoadPeoplesAsync(ST, txtSearch.Text));
                    btnDelete.Text = "فعال کردن";
                }
            }
        }
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

        private async Task LoadPeoplesAsync(bool status, string search = "")
        {
            try
            {
                list = await PeoplesBussines.GetAllAsync(search, GroupGuid);
                Invoke(new MethodInvoker(() =>
                    peopleBindingSource.DataSource = list.Where(q => q.Status == status).ToList()));
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
                var access = clsUser.CurrentUser.UserAccess;
                btnInsert.Enabled = access?.Peoples.People_Insert ?? false;
                btnEdit.Enabled = access?.Peoples.People_Update ?? false;
                btnDelete.Enabled = access?.Peoples.People_Delete ?? false;
                btnChangeStatus.Enabled = access?.Peoples.People_Disable ?? false;
                btnView.Enabled = access?.Peoples.People_View ?? false;
                btnBank.Enabled = access?.Peoples.People_Show_BankHesab ?? false;
                btnDelGroup.Enabled = access?.Peoples.People_Group_Delete ?? false;
                btnInsGroup.Enabled = access?.Peoples.People_Group_Insert ?? false;
                btnIpmortFromExcel.Enabled = access?.Peoples.People_Import_Excel ?? false;
                btnSendSMS.Enabled = access?.Peoples.People_SendSms ?? false;
                btnUpGroup.Enabled = access?.Peoples.People_Group_Update ?? false;
                btnTell.Enabled = access?.Peoples.People_Show_Tell ?? false;
                btnPrint.Enabled = access?.Peoples.People_Print ?? false;
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
                await LoadPeoplesAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmShowPeoples(bool _isShowMode)
        {
            InitializeComponent();
            isShowMode = _isShowMode;
            if (isShowMode)
            {
                btnDelete.Visible = false;
                btnInsert.Visible = false;
                btnEdit.Visible = false;
                btnGroups.Visible = false;
                btnView.Visible = false;
                btnChangeStatus.Visible = false;
                btnOther.Visible = false;
                btnSelect.Visible = true;
            }
            else
            {
                btnDelete.Visible = true;
                btnInsert.Visible = true;
                btnEdit.Visible = true;
                btnGroups.Visible = true;
                btnView.Visible = true;
                btnChangeStatus.Visible = true;
                btnOther.Visible = true;
                btnSelect.Visible = false;
            }

            SetAccess();
        }

        private void frmShowPeoples_Load(object sender, EventArgs e)
        {
            LoadData();
        }

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
                        btnInsert.PerformClick();
                        break;
                    case Keys.F7:
                        btnEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        btnDelete.PerformClick();
                        break;
                    case Keys.F12:
                        btnView.PerformClick();
                        break;
                    case Keys.S:
                        if (e.Control) ST = !ST;
                        break;
                    case Keys.Escape:
                        Close();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
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
                {
                    GroupGuid = Guid.Empty;
                }
                else
                {
                    var group = await PeopleGroupBussines.GetAsync(Guid.Parse(node.Name));
                    if (group != null)
                        GroupGuid = group.Guid;
                }
                await LoadPeoplesAsync(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadPeoplesAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void DGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                txtSearch.Focus();
                txtSearch.Text = e.KeyChar.ToString();
                txtSearch.SelectionStart = 9999;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                if (!ST)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        "شما مجاز به ویرایش داده حذف شده نمی باشید \r\n برای این منظور، ابتدا فیلد موردنظر را از حالت حذف شده به فعال، تغییر وضعیت دهید");
                    return;
                }
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmPeoples(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadPeoplesAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmPeoples(guid, true);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadPeoplesAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            ST = !ST;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                if (ST)
                {
                    var p = await PeoplesBussines.GetAsync(guid);
                    if (p == null) return;
                    if (p.Account != 0)
                    {
                        frmNotification.PublicInfo.ShowMessage(
                            "به دلیل داشتن گردش حساب، شما مجاز به حذف شخص نمی باشید");
                        return;
                    }
                    if (MessageBox.Show(this,
                            $@"آیا از حذف {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PeoplesBussines.GetAsync(guid);
                    var res = await prd.ChangeStatusAsync(false);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    if (MessageBox.Show(this,
                            $@"آیا شماره های شخص نیز از دفترچه تلفن حذف شود؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var prd2 = await PhoneBookBussines.GetAllAsync(guid, true);
                        foreach (var item in prd2)
                            await item.ChangeStatusAsync(false);
                    }

                    User.UserLog.Save(EnLogAction.Delete, EnLogPart.Peoples);

                }
                else
                {
                    if (MessageBox.Show(this,
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PeoplesBussines.GetAsync(guid);

                    if (prd.GroupGuid == Guid.Empty)
                    {
                        var frm = new frmChangeGroup(prd);
                        if (frm.ShowDialog(this) != DialogResult.OK) return;
                    }

                    var res = await prd.ChangeStatusAsync(true);
                    if (res.HasError)
                    {
                        frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                        return;
                    }

                    var prd2 = await PhoneBookBussines.GetAllAsync(guid, false);
                    foreach (var item in prd2)
                        await item.ChangeStatusAsync(true);

                    User.UserLog.Save(EnLogAction.Enable, EnLogPart.Peoples);

                }

                await LoadPeoplesAsync(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnInsGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPropleGroup();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnUpGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvGroup.SelectedNode == null) return;
                if (trvGroup.SelectedNode.Text == "همه گروه ها") return;
                var frm = new frmPropleGroup(GroupGuid);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnDelGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvGroup.SelectedNode == null) return;
                if (trvGroup.SelectedNode.Text == "همه گروه ها") return;

                var counter = await PeopleGroupBussines.ChildCountAsync(GroupGuid);
                if (counter > 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        $"گروه {trvGroup.SelectedNode.Text} بدلیل داشتن {counter} زیرگروه فعال، قادر به حذف نیست");
                    return;
                }

                var childes = await PeoplesBussines.GetAllAsync(GroupGuid, true);
                if (childes != null && childes.Count > 0)
                {
                    frmNotification.PublicInfo.ShowMessage(
                        $"گروه {trvGroup.SelectedNode.Text} بدلیل داشتن {childes.Count} شخص فعال، قادر به حذف نیست");
                    return;
                }
                if (MessageBox.Show(this,$@"آیا از حذف گروه {trvGroup.SelectedNode.Text} اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                var group = await PeopleGroupBussines.GetAsync(GroupGuid);
                var res = await group.ChangeStatusAsync(false);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                await LoadGroupsAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnTell_Click(object sender, EventArgs e)
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

        private void btnBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmPeoplesBankAccount(guid);
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnSendSMS_Click(object sender, EventArgs e)
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

        private void btnSelect_Click(object sender, EventArgs e)
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

        private void DGrid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!isShowMode) return;
                btnSelect.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnIpmortFromExcel_Click(object sender, EventArgs e)
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
        private void btnPrint_Click(object sender, EventArgs e)
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

                ExportToExcel.Export(list,this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
