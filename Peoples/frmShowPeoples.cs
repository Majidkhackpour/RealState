using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Microsoft.Office.Interop.Excel;
using Notification;
using Payamak;
using Payamak.PhoneBook;
using Services;

namespace Peoples
{
    public partial class frmShowPeoples : MetroForm
    {
        private Guid _groupGuid = Guid.Empty;
        public Guid GroupGuid { get => _groupGuid; set => _groupGuid = value; }
        public Guid SelectedGuid { get; set; }
        private bool isShowMode = false;
        private List<PeoplesBussines> list;
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
                    LoadPeoples(ST, txtSearch.Text);
                    btnDelete.Text = "حذف (Del)";
                }
                else
                {
                    btnChangeStatus.Text = "فعال (Ctrl+S)";
                    LoadPeoples(ST, txtSearch.Text);
                    btnDelete.Text = "فعال کردن";
                }
            }
        }
        private void LoadGroups()
        {
            try
            {
                var list = PeopleGroupBussines.GetAll().Where(q => q.Status).OrderBy(q => q.Name).ToList();
                groupBindingSource.DataSource = list;
                trvGroup.Nodes.Clear();
                var lst = PeopleGroupBussines.GetAll().Where(q => q.ParentGuid == Guid.Empty && q.Status)
                    .OrderBy(q => q.Name)
                    .ToList();
                var node = new TreeNode { Text = "همه گروه ها", Name = Guid.Empty.ToString() };
                trvGroup.Nodes.Add(node);
                foreach (var item in lst)
                {
                    node = new TreeNode { Text = item.Name, Name = item.Guid.ToString() };
                    trvGroup.Nodes.Add(node);
                }

                lst = PeopleGroupBussines.GetAll().Where(q => q.ParentGuid != Guid.Empty && q.Status)
                    .OrderBy(q => q.Name).ToList();
                foreach (var item in lst)
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

        private void LoadPeoples(bool status, string search = "")
        {
            try
            {
                list = PeoplesBussines.GetAll(search, GroupGuid).Where(q => q.Status == status).ToList();
                peopleBindingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void LoadData()
        {
            try
            {
                LoadGroups();
                LoadPeoples(ST, txtSearch.Text);
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
                LoadPeoples(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPeoples();
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadPeoples(ST, txtSearch.Text);
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

        private void btnEdit_Click(object sender, EventArgs e)
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
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadPeoples(ST, txtSearch.Text);
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
                frm.ShowDialog();
                LoadPeoples(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPeoples(ST, txtSearch.Text);
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
                    if (MessageBox.Show(
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

                    if (MessageBox.Show(
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
                    if (MessageBox.Show(
                            $@"آیا از فعال کردن {DGrid[dgName.Index, DGrid.CurrentRow.Index].Value} اطمینان دارید؟", "حذف",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.No) return;
                    var prd = await PeoplesBussines.GetAsync(guid);

                    if (prd.GroupGuid == Guid.Empty)
                    {
                        var frm = new frmChangeGroup(prd);
                        if (frm.ShowDialog() != DialogResult.OK) return;
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

                LoadPeoples(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnInsGroup_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmPropleGroup();
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGroups();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnUpGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (trvGroup.SelectedNode == null) return;
                if (trvGroup.SelectedNode.Text == "همه گروه ها") return;
                var frm = new frmPropleGroup(GroupGuid);
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadGroups();
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
                if (MessageBox.Show($@"آیا از حذف گروه {trvGroup.SelectedNode.Text} اطمینان دارید؟", "حذف", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                var group = await PeopleGroupBussines.GetAsync(GroupGuid);
                var res = await group.ChangeStatusAsync(false);
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                LoadGroups();
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
                frm.ShowDialog();
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
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var pe = PhoneBookBussines.GetAll(guid, true);

                var frm = new frmSendSms(pe.Select(q => q.Tell).ToList(), guid);
                frm.ShowDialog();
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
                if (frm.ShowDialog() == DialogResult.OK)
                    LoadPeoples(ST);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var sfd = new SaveFileDialog() { Filter = "Excel Files|*.xls" };
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var excel = new Microsoft.Office.Interop.Excel.Application();
                var wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
                var ws = (Worksheet)excel.ActiveSheet;
                excel.Visible = false;
                var index = 1;

                var frm = new frmSplash(list.Count);
                frm.Show();


                //Add column
                ws.Cells[1, 1] = "کد شخص";
                ws.Cells[1, 2] = "عنوان";
                ws.Cells[1, 3] = "کدملی";
                ws.Cells[1, 4] = "ش شناسنامه";
                ws.Cells[1, 5] = "نام پدر";
                ws.Cells[1, 6] = "محل تولد";
                ws.Cells[1, 7] = "تاریخ تولد";
                ws.Cells[1, 8] = "آدرس";
                ws.Cells[1, 9] = "کدپستی";
                ws.Cells[1, 10] = "مانده اول دوره";
                ws.Cells[1, 11] = "مانده فعلی";
                ws.Cells[1, 12] = "وضعیت حساب";


                foreach (var item in list)
                {
                    index++;
                    frm.Level = index;

                    ws.Cells[index, 1] = item.Code;
                    ws.Cells[index, 2] = item.Name;
                    ws.Cells[index, 3] = item.NationalCode;
                    ws.Cells[index, 4] = item.IdCode;
                    ws.Cells[index, 5] = item.FatherName;
                    ws.Cells[index, 6] = item.PlaceBirth;
                    ws.Cells[index, 7] = item.DateBirth;
                    ws.Cells[index, 8] = item.Address;
                    ws.Cells[index, 9] = item.PostalCode;
                    ws.Cells[index, 10] = item.AccountFirst.ToString("N0");
                    ws.Cells[index, 11] = item.Account_.ToString("N0");
                    if (item.Account == 0) ws.Cells[index, 12] = "بی حساب";
                    if (item.Account > 0) ws.Cells[index, 12] = "بدهکار";
                    if (item.Account < 0) ws.Cells[index, 12] = "بستانکار";
                }


                ws.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false,
                    XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing,
                    Type.Missing);
                excel.Quit();
                frm.Close();

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
