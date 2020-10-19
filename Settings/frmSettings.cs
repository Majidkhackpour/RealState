using System;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Forms;
using Services;
using Settings.SettingForms;

namespace Settings
{
    public partial class frmSettings : MetroForm
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        #region LblSetter
        private void lblEconomyUnit_MouseEnter(object sender, System.EventArgs e)
        {
            lblEconomyUnit.ForeColor = Color.Red;
        }

        private void lblSandouq_MouseEnter(object sender, System.EventArgs e)
        {
            lblSandouq.ForeColor = Color.Red;
        }

        private void lblSms_MouseEnter(object sender, System.EventArgs e)
        {
            lblSms.ForeColor = Color.Red;
        }

        private void lblTelegram_MouseEnter(object sender, System.EventArgs e)
        {
            lblTelegram.ForeColor = Color.Red;
        }

        private void lblRobot_MouseEnter(object sender, System.EventArgs e)
        {
            lblRobot.ForeColor = Color.Red;
        }

        private void lblBackUp_MouseEnter(object sender, System.EventArgs e)
        {
            lblBackUp.ForeColor = Color.Red;
        }

        private void lblBackUp_MouseLeave(object sender, System.EventArgs e)
        {
            lblBackUp.ForeColor = Color.Black;
        }

        private void lblRobot_MouseLeave(object sender, System.EventArgs e)
        {
            lblRobot.ForeColor = Color.Black;
        }

        private void lblTelegram_MouseLeave(object sender, System.EventArgs e)
        {
            lblTelegram.ForeColor = Color.Black;
        }

        private void lblSms_MouseLeave(object sender, System.EventArgs e)
        {
            lblSms.ForeColor = Color.Black;
        }

        private void lblSandouq_MouseLeave(object sender, System.EventArgs e)
        {
            lblSandouq.ForeColor = Color.Black;
        }

        private void lblEconomyUnit_MouseLeave(object sender, System.EventArgs e)
        {
            lblEconomyUnit.ForeColor = Color.Black;
        }
        #endregion

        public void LoadNewForm(Form frm)
        {
            try
            {
                frm.TopLevel = false;
                frm.AutoScroll = true;
                frm.ControlBox = false;
                frm.Dock = DockStyle.Fill;
                pnlContent.Controls.Clear();
                pnlContent.BringToFront();
                pnlContent.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                pnlContent.AutoScroll = true;
                frm.Show(this);
            }
            catch (Exception ex)
            {
                //WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblEconomyUnit_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewForm(new frmEconomy());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblSandouq_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewForm(new frmSandouq());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblSms_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewForm(new frmSmsSetting());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblTelegram_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewForm(new frmTelegramSetting());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblRobot_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void lblBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNewForm(new frmBackUpSetting());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmSettings_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
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
