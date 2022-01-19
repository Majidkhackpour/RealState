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
    public partial class frmSandouq : MetroForm
    {
        private void LoadSandouqAsync()
        {
            try
            {
                FillCmbSandouq();
                var sett = SettingsBussines.Setting;
                txtSCode.Text = sett.SafeBox.NationalCode;
                txtSNatCode.Text = sett.SafeBox.NationalCode;
                txtSIdCode.Text = sett.SafeBox.IdCode;
                txtSArzesh.Text = sett.SafeBox.ArzeshAfzoude.ToString();
                txtSTabdil.Text = sett.SafeBox.Tabdil.ToString();
                cmbSType.Text = sett.SafeBox.EconomyCodeStatus;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbSandouq()
        {
            try
            {
                cmbSType.Items.Add(EnEconomyCodeStatus.HasUserName.GetDisplay());
                cmbSType.Items.Add(EnEconomyCodeStatus.HasCode.GetDisplay());
                cmbSType.Items.Add(EnEconomyCodeStatus.DontHave.GetDisplay());

                cmbSType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SaveSandouqAsync()
        {
            try
            {
                SettingsBussines.Setting.SafeBox.NationalCode = txtSCode.Text;
                SettingsBussines.Setting.SafeBox.NationalCode = txtSNatCode.Text;
                SettingsBussines.Setting.SafeBox.IdCode = txtSIdCode.Text;
                SettingsBussines.Setting.SafeBox.ArzeshAfzoude = txtSArzesh.Text.ParseToDouble();
                SettingsBussines.Setting.SafeBox.Tabdil = txtSTabdil.Text.ParseToDouble();
                SettingsBussines.Setting.SafeBox.EconomyCodeStatus = cmbSType.Text;

                await SettingsBussines.Setting.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSandouq() => InitializeComponent();
        private void frmSandouq_Load(object sender, System.EventArgs e) => LoadSandouqAsync();
        private async void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                await SaveSandouqAsync();
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
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmSandouq_KeyDown(object sender, KeyEventArgs e)
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
