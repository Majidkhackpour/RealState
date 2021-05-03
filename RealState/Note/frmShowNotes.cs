using System;
using System.Linq;
using System.Threading;
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
        private CancellationTokenSource _token = new CancellationTokenSource();

        private async Task FillCmbAsync()
        {
            try
            {
                _token?.Cancel();
                _token = new CancellationTokenSource();
                var list = await UserBussines.GetAllAsync(_token.Token);
                list.Add(new UserBussines()
                {
                    Guid = Guid.Empty,
                    Name = "[کلیه کاربران]"
                });
                userBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
                cmbUsers.SelectedValue = UserBussines.CurrentUser.Guid;


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
                        mnuAdd.PerformClick();
                        break;
                    case Keys.F7:
                        mnuEdit.PerformClick();
                        break;
                    case Keys.Delete:
                        mnuDelete.PerformClick();
                        break;
                    case Keys.F:
                        if (e.Control) txtSearch.Focus();
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
        private void mnuView_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGrid.RowCount <= 0) return;
                if (DGrid.CurrentRow == null) return;
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmNoteMain(guid, true);
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
                var guid = (Guid)DGrid[dgGuid.Index, DGrid.CurrentRow.Index].Value;
                var frm = new frmNoteMain(guid, false);
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync(txtSearch.Text);
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
                var frm = new frmNoteMain();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
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

                if (MessageBox.Show(this,
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
        private async void mnuLog_Click(object sender, EventArgs e)
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

                if (MessageBox.Show(this,
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
        private async void mnuRemain_Click(object sender, EventArgs e)
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

                if (MessageBox.Show(this,
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
    }
}
