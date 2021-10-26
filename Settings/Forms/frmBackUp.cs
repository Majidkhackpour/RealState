using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings.Forms
{
    public partial class frmBackUp : MetroForm
    {
        private void LoadBackUp()
        {
            try
            {
                txtPath.Text = clsBackUp.BackUpPath;
                chbAuto.Checked = clsBackUp.IsAutoBackUp.ParseToBoolean();
                txtTime.Text = clsBackUp.BackUpDuration;
                chbBackUpSms.Checked = clsBackUp.BackUpSms.ParseToBoolean();
                chbOpen.Checked = clsBackUp.BackUpOpen.ParseToBoolean();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SaveBackUp()
        {
            try
            {
                clsBackUp.BackUpPath = txtPath.Text;
                clsBackUp.BackUpDuration = txtTime.Text;
                clsBackUp.IsAutoBackUp = chbAuto.Checked.ToString();
                clsBackUp.BackUpSms = chbBackUpSms.Checked.ToString();
                clsBackUp.BackUpOpen = chbOpen.Checked.ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBackUp() => InitializeComponent();
        private void frmBackUp_Load(object sender, EventArgs e) => LoadBackUp();
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveBackUp();
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
        private void frmBackUp_KeyDown(object sender, KeyEventArgs e)
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
