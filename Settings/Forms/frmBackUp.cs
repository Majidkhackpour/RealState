using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;
using Services.Settings;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings.Forms
{
    public partial class frmBackUp : MetroForm
    {
        private void LoadBackUp()
        {
            try
            {
                var sett = SettingsBussines.Setting;
                
                txtPath.Text = sett.BackUp.BackUpPath;
                chbAuto.Checked = sett.BackUp.IsAutoBackUp;
                txtTime.Value = sett.BackUp.BackUpDuration;
                chbBackUpSms.Checked = sett.BackUp.BackUpSms;
                chbOpen.Checked = sett.BackUp.BackUpOpen;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveBackUpAsync()
        {
            try
            {
                SettingsBussines.Setting.BackUp.BackUpPath = txtPath.Text;
                SettingsBussines.Setting.BackUp.BackUpDuration = (int) txtTime.Value;
                SettingsBussines.Setting.BackUp.IsAutoBackUp = chbAuto.Checked;
                SettingsBussines.Setting.BackUp.BackUpSms = chbBackUpSms.Checked;
                SettingsBussines.Setting.BackUp.BackUpOpen = chbOpen.Checked;

                await SettingsBussines.Setting.SaveAsync();
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
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                await SaveBackUpAsync();
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
