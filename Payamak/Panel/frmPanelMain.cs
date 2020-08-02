using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using PacketParser;
using PacketParser.Services;

namespace Payamak.Panel
{
    public partial class frmPanelMain : MetroForm
    {
        private SmsPanelsBussines cls;
        private void SetData()
        {
            try
            {
                txtName.Text = cls?.Name;
                txtUserName.Text = cls?.UserName;
                txtPassword.Text = cls?.Password;
                txtSender.Text = cls?.Sender;
                txtApi.Text = cls?.API;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPanelMain()
        {
            InitializeComponent();
            cls = new SmsPanelsBussines();
        }
        public frmPanelMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = SmsPanelsBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void frmPanelMain_Load(object sender, EventArgs e)
        {
            SetData();
        }

        #region TxtSetter
        private void txtName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtUserName);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtPassword);
        }

        private void txtSender_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtSender);
        }

        private void txtApi_Enter(object sender, EventArgs e)
        {
            txtSetter.Focus(txtApi);
        }

        private void txtApi_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtApi);
        }

        private void txtSender_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtSender);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtPassword);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtUserName);
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmPanelMain_KeyDown(object sender, KeyEventArgs e)
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

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("عنوان نمی تواند خالی باشد");
                    txtName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("نام کاربری نمی تواند خالی باشد");
                    txtUserName.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("کلمه عبور نمی تواند خالی باشد");
                    txtPassword.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSender.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("شماره خط فرستنده عبور نمی تواند خالی باشد");
                    txtSender.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtApi.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("وب سرویس عبور نمی تواند خالی باشد");
                    txtApi.Focus();
                    return;
                }

                cls.Name = txtName.Text.Trim();
                cls.UserName = txtUserName.Text.Trim();
                cls.Password = txtPassword.Text.Trim();
                cls.Sender = txtSender.Text.Trim();
                cls.API = txtApi.Text.Trim();

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
    }
}
