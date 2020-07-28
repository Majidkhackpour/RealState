using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using EntityCache.Bussines;
using Notification;
using PacketParser.Services;

namespace User
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (txtPass1.Focused) pnlOk_Click(null, null);
                        if (txtUserName.Focused)
                            SendKeys.Send("{Tab}");
                        break;
                    case Keys.Escape:
                        DialogResult = DialogResult.Cancel;
                        Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void pnlOk_MouseEnter(object sender, EventArgs e)
        {
            pnlOk.BackColor = Color.Silver;
        }

        private void pnlOk_MouseLeave(object sender, EventArgs e)
        {
            pnlOk.BackColor = Color.Empty;
        }

        private void pnlExit_MouseEnter(object sender, EventArgs e)
        {
            pnlExit.BackColor = Color.Silver;
        }

        private void pnlExit_MouseLeave(object sender, EventArgs e)
        {
            pnlExit.BackColor = Color.Empty;
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                var myCollection = new AutoCompleteStringCollection();
                var list = await UserBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.UserName);
                txtUserName.AutoCompleteCustomSource = myCollection;


                txtUserName.Text = SettingsBussines.LastUser;
                if (!string.IsNullOrEmpty(txtUserName.Text)) txtPass1.Focus();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void pnlExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void pnlOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("نام کاربری نمی تواند خالی باشد");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPass1.Text))
                {
                    frmNotification.PublicInfo.ShowMessage("کلمه عبور نمی تواند خالی باشد");
                    txtPass1.Focus();
                    txtPass1.SelectAll();
                    return;
                }

                var user = await UserBussines.GetAsync(txtUserName.Text.Trim());
                if (user == null)
                {
                    frmNotification.PublicInfo.ShowMessage($"کاربر با نام کاربری {txtUserName.Text} یافت نشد");
                    txtUserName.Focus();
                    txtUserName.SelectAll();
                    return;
                }

                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes(txtPass1.Text.Trim());
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                var password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                if (password == user.Password)
                {
                    frmNotification.PublicInfo.ShowMessage("رمز عبور اشتباه است");
                    txtPass1.Focus();
                    txtPass1.SelectAll();
                    return;
                }

                clsUser.CurrentUser = user;
                clsUser.DateVorrod = DateTime.Now;

                SettingsBussines.LastUser = user.UserName;

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblRecoveryPassword_MouseEnter(object sender, EventArgs e)
        {
            lblRecoveryPassword.ForeColor = Color.Red;
        }

        private void lblRecoveryPassword_MouseLeave(object sender, EventArgs e)
        {
            lblRecoveryPassword.ForeColor = Color.Black;
        }
    }
}
