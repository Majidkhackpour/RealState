using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;

namespace Settings.Forms
{
    public partial class frmSetting : MetroForm
    {
        private void PublicSetting()
        {
            try
            {
                var frm = new frmPublicSetting();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void EconomyUnit()
        {
            try
            {
                var frm = new frmEconomyUnit();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Sandouq()
        {
            try
            {
                var frm = new frmSandouq();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Sms()
        {
            try
            {
                var frm = new frmSms();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void Telegram()
        {
            try
            {
                var frm = new frmTelegram();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void WhatsApp()
        {
            try
            {
                var frm = new frmWhatsApp();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void BackUp()
        {
            try
            {
                var frm = new frmBackUp();
                frm.ShowDialog(this);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }


        public frmSetting()
        {
            InitializeComponent();
            ucHeader.Text = "تنظیمات برنامه";
        }


        private void lblPublic_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblPublic);
        private void lblPublic_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblPublic);
        private void lblEconomyUnit_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblEconomyUnit);
        private void lblEconomyUnit_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblEconomyUnit);
        private void lblSandouq_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblSandouq);
        private void lblSandouq_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblSandouq);
        private void lblSms_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblSms);
        private void lblSms_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblSms);
        private void lblTelegram_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblTelegram);
        private void lblTelegram_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblTelegram);
        private void lblWhatsapp_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblWhatsapp);
        private void lblWhatsapp_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblWhatsapp);
        private void lblBackUp_MouseEnter(object sender, System.EventArgs e) => txtSetter.Focus(lblBackUp);
        private void lblBackUp_MouseLeave(object sender, System.EventArgs e) => txtSetter.Follow(lblBackUp);
        private void picPublic_Click(object sender, System.EventArgs e) => PublicSetting();
        private void lblPublic_Click(object sender, System.EventArgs e) => PublicSetting();
        private void picEconomyUnit_Click(object sender, System.EventArgs e) => EconomyUnit();
        private void lblEconomyUnit_Click(object sender, System.EventArgs e) => EconomyUnit();
        private void picSandouq_Click(object sender, System.EventArgs e) => Sandouq();
        private void lblSandouq_Click(object sender, System.EventArgs e) => Sandouq();
        private void picSms_Click(object sender, System.EventArgs e) => Sms();
        private void lblSms_Click(object sender, System.EventArgs e) => Sms();
        private void picTelegram_Click(object sender, System.EventArgs e) => Telegram();
        private void lblTelegram_Click(object sender, System.EventArgs e) => Telegram();
        private void picWhatsapp_Click(object sender, System.EventArgs e) => WhatsApp();
        private void lblWhatsapp_Click(object sender, System.EventArgs e) => WhatsApp();
        private void picBackUp_Click(object sender, System.EventArgs e) => BackUp();
        private void lblBackUp_Click(object sender, System.EventArgs e) => BackUp();
        private void frmSetting_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
