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
    public partial class frmPublicSetting : MetroForm
    {
        private void LoadGlobal()
        {
            try
            {
                var sett = SettingsBussines.Setting;
                txtBirthDayText.Text = sett.Global.BirthDayText;
                txtSetArchive.Value = sett.Global.SetArchive;
                chbPrintDesign.Checked = sett.Print.ShowDesign;
                chbPrintPreView.Checked = sett.Print.ShowPreview;
                txtImagePath.Text = sett.Global.ImagePath;
                txtMediaPath.Text = sett.Global.MediaPath;
                chbShowDialog.Checked = sett.Global.ShowDialog;
                chbDeleteRequest.Checked = sett.Global.DeleteRequest;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveGlobalAsync()
        {
            try
            {
                SettingsBussines.Setting.Global.BirthDayText = txtBirthDayText.Text;
                SettingsBussines.Setting.Global.SetArchive = (int)txtSetArchive.Value;
                SettingsBussines.Setting.Print.ShowDesign = chbPrintDesign.Checked;
                SettingsBussines.Setting.Print.ShowPreview = chbPrintPreView.Checked;
                SettingsBussines.Setting.Global.ImagePath = txtImagePath.Text;
                SettingsBussines.Setting.Global.MediaPath = txtMediaPath.Text;
                SettingsBussines.Setting.Global.ShowDialog = chbShowDialog.Checked;
                SettingsBussines.Setting.Global.DeleteRequest = chbDeleteRequest.Checked;

                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmPublicSetting() => InitializeComponent();
        private void frmPublicSetting_Load(object sender, EventArgs e) => LoadGlobal();
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
                await SaveGlobalAsync();
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
        private void frmPublicSetting_KeyDown(object sender, KeyEventArgs e)
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
        private void btnSearchImagePath_Click(object sender, EventArgs e)
        {
            try
            {
                var ff = new FolderBrowserDialog();
                if (ff.ShowDialog(this) == DialogResult.OK)
                    txtImagePath.Text = ff.SelectedPath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnSearchMedia_Click(object sender, EventArgs e)
        {
            try
            {
                var ff = new FolderBrowserDialog();
                if (ff.ShowDialog(this) == DialogResult.OK)
                    txtMediaPath.Text = ff.SelectedPath;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
