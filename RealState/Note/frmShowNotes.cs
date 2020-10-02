using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using User;

namespace RealState.Note
{
    public partial class frmShowNotes : MetroForm
    {
        private async Task FillCmbAsync()
        {
            try
            {

                var list = await UserBussines.GetAllAsync();
                list.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[کلیه کاربران]"
                });
                userBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
                cmbUsers.SelectedValue = clsUser.CurrentUser.Guid;


                cmbPriority.Items.Add(EnNotePriority.All.GetDisplay());
                cmbPriority.Items.Add(EnNotePriority.Mamoli.GetDisplay());
                cmbPriority.Items.Add(EnNotePriority.Mohem.GetDisplay());
                cmbPriority.Items.Add(EnNotePriority.Zarori.GetDisplay());
                cmbPriority.SelectedIndex = 0;


                cmbStatus.Items.Add(EnNoteStatus.All.GetDisplay());
                cmbStatus.Items.Add(EnNoteStatus.Unread.GetDisplay());
                cmbStatus.Items.Add(EnNoteStatus.Read.GetDisplay());
                cmbStatus.Items.Add(EnNoteStatus.Deleted.GetDisplay());
                cmbStatus.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadDataAsync(string search = "")
        {
            try
            {
                if (cmbUsers.SelectedValue == null) return;
                var list = await NoteBussines.GetAllAsync(search, (Guid)cmbUsers.SelectedValue,
                    (EnNoteStatus)cmbStatus.SelectedIndex, (EnNotePriority)cmbPriority.SelectedIndex);
                noteBindingSource.DataSource = list.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmShowNotes()
        {
            InitializeComponent();
        }

        private async void frmShowNotes_Load(object sender, EventArgs e)
        {
            await FillCmbAsync();
            await LoadDataAsync();
        }

        private void DGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGrid.Rows[e.RowIndex].Cells["Radif"].Value = e.RowIndex + 1;
        }

        private async void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmShowNotes_KeyDown(object sender, KeyEventArgs e)
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
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
                        break;
                    case Keys.Escape: Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnChangeStatus_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var note = await NoteBussines.GetAsync(guid);
                if (note == null) return;
                if (note.NoteStatus == EnNoteStatus.Read)
                {
                    frmNotification.PublicInfo.ShowMessage("یادداشت انتخاب شده درحال حاظر در وضعیت خوانده شده می باشد");
                    return;
                }

                if (MessageBox.Show(
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                note.NoteStatus = EnNoteStatus.Read;
                var res = await note.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var note = await NoteBussines.GetAsync(guid);
                if (note == null) return;
                if (note.NoteStatus == EnNoteStatus.Unread)
                {
                    frmNotification.PublicInfo.ShowMessage("یادداشت انتخاب شده درحال حاظر در وضعیت خوانده نشده می باشد");
                    return;
                }

                if (MessageBox.Show(
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                note.NoteStatus = EnNoteStatus.Unread;
                var res = await note.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                await LoadDataAsync(txtSearch.Text);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var note = await NoteBussines.GetAsync(guid);
                if (note == null) return;
                if (note.NoteStatus == EnNoteStatus.Deleted)
                {
                    frmNotification.PublicInfo.ShowMessage("یادداشت انتخاب شده درحال حاظر در وضعیت حذف شده می باشد");
                    return;
                }

                if (MessageBox.Show(
                        $@"آیا از اعمال تغییرات اطمینان دارید؟", "حذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No) return;
                note.NoteStatus = EnNoteStatus.Deleted;
                var res = await note.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                await LoadDataAsync(txtSearch.Text);
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
                var frm = new frmNoteMain();
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync();
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
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmNoteMain(guid, false);
                if (frm.ShowDialog() == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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
                var frm = new frmNoteMain(guid, true);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
