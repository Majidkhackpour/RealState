using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings.Forms
{
    public partial class frmWhatsApp : MetroForm
    {
        private void LoadWhatsApp()
        {
            try
            {
                txtWhatsAppCustomerText.Text = clsWhatsApp.CustomerMessage;
                txtWhatsAppManagerText.Text = clsWhatsApp.ManagerMessage;
                txtWhatsAppNumber.Text = clsWhatsApp.Number;
                txtWhatsAppToken.Text = clsWhatsApp.ApiCode;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveWhatsApp()
        {
            try
            {
                clsWhatsApp.CustomerMessage = txtWhatsAppCustomerText.Text;
                clsWhatsApp.ManagerMessage = txtWhatsAppManagerText.Text;
                clsWhatsApp.Number = txtWhatsAppNumber.Text;
                clsWhatsApp.ApiCode = txtWhatsAppToken.Text;
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
                    txtWhatsAppCustomerText.Text = clsWhatsApp.CustomerMessage;
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
                    txtWhatsAppManagerText.Text = clsWhatsApp.ManagerMessage;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmWhatsApp_Load(object sender, EventArgs e) => LoadWhatsApp();
        private void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveWhatsApp();
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
