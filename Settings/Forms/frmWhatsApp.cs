using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings.Forms
{
    public partial class frmWhatsApp : MetroForm
    {
        private void LoadWhatsApp()
        {
            try
            {
                var sett = SettingsBussines.Setting;

                txtWhatsAppCustomerText.Text = sett.Whatsapp.CustomerMessage;
                txtWhatsAppManagerText.Text = sett.Whatsapp.ManagerMessage;
                txtWhatsAppNumber.Text = sett.Whatsapp.Number;
                txtWhatsAppToken.Text = sett.Whatsapp.ApiCode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveWhatsAppAsync()
        {
            try
            {
                SettingsBussines.Setting.Whatsapp.CustomerMessage = txtWhatsAppCustomerText.Text;
                SettingsBussines.Setting.Whatsapp.ManagerMessage = txtWhatsAppManagerText.Text;
                SettingsBussines.Setting.Whatsapp.Number = txtWhatsAppNumber.Text;
                SettingsBussines.Setting.Whatsapp.ApiCode = txtWhatsAppToken.Text;

                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmWhatsApp() => InitializeComponent();
        private void btnWhatsAppCustomer_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmWhatsAppCutomerText();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    txtWhatsAppCustomerText.Text = SettingsBussines.Setting.Whatsapp.CustomerMessage;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnWhatsAppManager_Click(object sender, System.EventArgs e)
        {
            try
            {
                var frm = new frmWhatsAppManagerText();
                if (frm.ShowDialog(this) == DialogResult.OK)
                    txtWhatsAppManagerText.Text = SettingsBussines.Setting.Whatsapp.ManagerMessage;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmWhatsApp_Load(object sender, EventArgs e) => LoadWhatsApp();
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                await SaveWhatsAppAsync();
                frmNotification.PublicInfo.ShowMessage("تنظیمات با موفقیت ثبت شد");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            finally
            {
                btnFinish.Enabled = true;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmWhatsApp_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape) btnCancel.PerformClick();
                else if (e.KeyCode == Keys.F5) btnFinish.PerformClick();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
