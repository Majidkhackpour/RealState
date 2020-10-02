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
    public partial class frmNoteMain : MetroForm
    {
        private NoteBussines cls;

        private async Task SetDataAsync()
        {
            try
            {

                var list = await UserBussines.GetAllAsync();
                userBindingSource.DataSource = list.OrderBy(q => q.Name);
                cmbUsers.SelectedValue = clsUser.CurrentUser.Guid;



                cmbPriority.Items.Add(EnNotePriority.Mamoli.GetDisplay());
                cmbPriority.Items.Add(EnNotePriority.Mohem.GetDisplay());
                cmbPriority.Items.Add(EnNotePriority.Zarori.GetDisplay());
                chbSarresid.Checked = false;
                lblSarresid.Visible = false;
                txtSarresid.Visible = false;

                txtTitle.Text = cls?.Title;
                txtDescription.Text = cls?.Description;
                if (cls?.DateSarresid == null) chbSarresid.Checked = false;
                else
                {
                    chbSarresid.Checked = true;
                    txtSarresid.Text = Calendar.MiladiToShamsi(cls?.DateSarresid);
                }

                cmbUsers.SelectedValue = cls?.UserGuid;
                cmbPriority.SelectedIndex = (int)(cls?.Priority - 1);
                if (cls?.Guid == Guid.Empty)
                {
                    cmbPriority.SelectedIndex = 0;
                    cmbUsers.SelectedValue = clsUser.CurrentUser.Guid;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmNoteMain()
        {
            InitializeComponent();
            cls = new NoteBussines();
        }

        public frmNoteMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = NoteBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private async void frmNoteMain_Load(object sender, EventArgs e)
        {
            await SetDataAsync();
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtTitle);
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtTitle);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان نمی تواند خالی باشد");
                    txtTitle.Focus();
                    return;
                }


                cls.Title = txtTitle.Text.Trim();
                cls.Description = txtDescription.Text;
                cls.Priority = (EnNotePriority)(cmbPriority.SelectedIndex + 1);
                if (chbSarresid.Checked) cls.DateSarresid = Calendar.ShamsiToMiladi(txtSarresid.Text);
                cls.NoteStatus = EnNoteStatus.Unread;
                cls.UserGuid = (Guid)cmbUsers.SelectedValue;

                var res = await cls.SaveAsync();
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }

        private void chbSarresid_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbSarresid.Checked)
                {
                    lblSarresid.Visible = true;
                    txtSarresid.Visible = true;
                }
                else
                {
                    lblSarresid.Visible = false;
                    txtSarresid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmNoteMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (!btnFinish.Focused && !btnCancel.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.F5:
                        btnFinish.PerformClick();
                        break;
                    case Keys.Escape:
                        btnCancel.PerformClick();
                        break;
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }
        }
    }
}
