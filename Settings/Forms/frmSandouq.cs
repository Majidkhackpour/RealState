using System;
using System.Windows.Forms;
using MetroFramework.Forms;
using Notification;
using Services;
using Settings.Classes;

namespace Settings.Forms
{
    public partial class frmSandouq : MetroForm
    {
        private void LoadSandouqAsync()
        {
            try
            {
                FillCmbSandouq();

                txtSCode.Text = clsSandouq.NationalCode;
                txtSNatCode.Text = clsSandouq.NationalCode;
                txtSIdCode.Text = clsSandouq.IdCode;
                txtSArzesh.Text = clsSandouq.ArzeshAfzoude;
                txtSTabdil.Text = clsSandouq.Tabdil;
                cmbSType.Text = clsSandouq.EconomyCodeStatus;
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
        private void SaveSandouq()
        {
            try
            {
                clsSandouq.NationalCode = txtSCode.Text;
                clsSandouq.NationalCode = txtSNatCode.Text;
                clsSandouq.IdCode = txtSIdCode.Text;
                clsSandouq.ArzeshAfzoude = txtSArzesh.Text;
                clsSandouq.Tabdil = txtSTabdil.Text;
                clsSandouq.EconomyCodeStatus = cmbSType.Text;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSandouq() => InitializeComponent();
        private void frmSandouq_Load(object sender, System.EventArgs e) => LoadSandouqAsync();
        private void btnFinish_Click(object sender, System.EventArgs e)
        {
            btnFinish.Enabled = false;
            try
            {
                SaveSandouq();
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
