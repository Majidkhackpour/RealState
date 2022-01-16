using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace User
{
    public partial class frmRegisterPassword : MetroForm
    {
        private UserBussines cls;
        private short _type;
        public frmRegisterPassword(UserBussines user, short type)
        {
            InitializeComponent();
            cls = user;
            _type = type;
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
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(txtPass1.Text))
                {
                    res.AddError("کلمه عبور نمی تواند خالی باشد");
                    txtPass1.Focus();
                }

                if (string.IsNullOrWhiteSpace(txtPass2.Text))
                {
                    res.AddError("تکرار کلمه عبور نمی تواند خالی باشد");
                    txtPass2.Focus();
                }

                if (txtPass1.Text != txtPass2.Text)
                {
                    res.AddError("کلمه عبور با تکرار آن همخوانی ندارد");
                    txtPass1.Focus();
                }

                if (res.HasError) return;
                var ue = new UTF8Encoding();
                var bytes = ue.GetBytes(txtPass1.Text.Trim());
                var md5 = new MD5CryptoServiceProvider();
                var hashBytes = md5.ComputeHash(bytes);
                cls.Password = System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(hashBytes), "-", "")
                    .ToLower();
                cls.ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await cls.SaveAsync());
                if (res.HasError)
                {
                    frmNotification.PublicInfo.ShowMessage(res.ErrorMessage);
                    return;
                }

                var text = $"کاربر گرامی: {cls?.Name} عزیز " +
                           $"\r\n در تاریخ {Calendar.MiladiToShamsi(DateTime.Now)} رمز ورود به سیستم شما تعویض شد" +
                           $"\r\n گروه مهندسی آراد";

                if (_type != 0) return;
                if (string.IsNullOrEmpty(Settings.Classes.Payamak.DefaultPanelGuid))
                    return;

                var panel = await SmsPanelsBussines.GetAsync(Guid.Parse(Settings.Classes.Payamak.DefaultPanelGuid));
                if (panel == null) return;

                var sApi = new Sms.Api(panel.API.Trim());


                var result = sApi.Send(panel.Sender, cls?.Mobile ?? "", text);

                var smsLog = new SmsLogBussines()
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = cls?.Guid ?? Guid.Empty,
                    Cost = result.Cost,
                    Message = result.Message,
                    MessageId = result.Messageid,
                    Reciver = result.Receptor,
                    Sender = result.Sender,
                    StatusText = result.StatusText
                };

                res.AddReturnedValue(await smsLog.SaveAsync());
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت رمز عبور کاربر");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
