using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Payamak.PhoneBook;
using Services;

namespace Peoples
{
    public partial class frmShowPeoples : MetroForm
    {
        private Guid _groupGuid = Guid.Empty;
        public Guid GroupGuid { get => _groupGuid; set => _groupGuid = value; }
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
                var list = PeoplesBussines.GetAll(search, GroupGuid).Where(q => q.Status == status).ToList();
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
        public frmShowPeoples()
        {
            InitializeComponent();
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

        private void mnuAdd_Click(object sender, EventArgs e)
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

        private void mnuEdit_Click(object sender, EventArgs e)
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

        private async void mnuDelete_Click(object sender, EventArgs e)
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
                }

                LoadPeoples(ST, txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void mnuBank_Click(object sender, EventArgs e)
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

        private void mnuPhone_Click(object sender, EventArgs e)
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

        private void lblMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                cmPeoples.Visible = true;
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
                mnuAdd_Click(null, null);
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
                mnuEdit_Click(null, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnDelGroup_Click(object sender, EventArgs e)
        {
            try
            {
                mnuDelete_Click(null, null);
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
                mnuPhone_Click(null, null);
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
                mnuBank_Click(null, null);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            
        }
    }
}
