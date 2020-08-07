using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace User
{
    public partial class frmRegisterPassword : MetroForm
    {
        private UserBussines cls;
        public frmRegisterPassword(UserBussines user)
        {
            InitializeComponent();
            cls = user;
        }

        private void txtPass1_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtPass1);
        }

        private void txtPass2_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtPass2);
        }

        private void txtPass2_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtPass2);
        }

        private void txtPass1_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtPass1);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void frmRegisterPassword_KeyDown(object sender, KeyEventArgs e)
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

                if (string.IsNullOrWhiteSpace(txtPass1.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("کلمه عبور نمی تواند خالی باشد");
                    txtPass1.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPass2.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("تکرار کلمه عبور نمی تواند خالی باشد");
                    txtPass2.Focus();
                    return;
                }
                if (txtPass1.Text != txtPass2.Text)
                {
                    frmNotification.PublicInfo.ShowMessage("کلمه عبور با تکرار آن همخوانی ندارد");
                    txtPass1.Focus();
                    return;
                }

                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes(txtPass1.Text.Trim());
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                cls.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();

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
