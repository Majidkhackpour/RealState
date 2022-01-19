using EntityCache.Assistence;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Settings
{
    public partial class frmEconomyUnit : MetroForm
    {
        private CancellationTokenSource token = new CancellationTokenSource();
        public frmEconomyUnit()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region TxtSetter
        private void txtName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtName);
        }

        private void txtMobile_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtMobile);
        }

        private void txtManagerName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtManagerName);
        }

        private void txtTell_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtTell);
        }

        private void txtFax_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtFax);
        }

        private void txtEmail_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtEmail);
        }

        private void txtAddress_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtAddress);
        }

        private void txtAddress_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtAddress);
        }

        private void txtEmail_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtEmail);
        }

        private void txtFax_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtFax);
        }

        private void txtTell_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtTell);
        }

        private void txtManagerName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtManagerName);
        }

        private void txtMobile_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtMobile);
        }

        private void txtName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtName);
        }
        #endregion

        private async Task SettDataAsync()
        {
            try
            {
                await FillCmbAsync();
                var sett = SettingsBussines.Setting;
                txtName.Text = sett.CompanyInfo.EconomyName;
                txtMobile.Text = sett.CompanyInfo.ManagerMobile;
                txtTell.Text = sett.CompanyInfo.ManagerTell;
                txtFax.Text = sett.CompanyInfo.ManagerFax;
                txtManagerName.Text = sett.CompanyInfo.ManagerName;
                txtEmail.Text = sett.CompanyInfo.ManagerEmail;
                txtAddress.Text = sett.CompanyInfo.ManagerAddress;
                if (string.IsNullOrEmpty(sett.CompanyInfo.EconomyType)) cmbType.SelectedIndex = 0;
                else
                    cmbType.Text = sett.CompanyInfo.EconomyType;
                if (sett.CompanyInfo.EconomyState == Guid.Empty)
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedValue = sett.CompanyInfo.EconomyState;
                if (sett.CompanyInfo.EconomyCity != Guid.Empty)
                    cmbCity.SelectedValue = sett.CompanyInfo.EconomyCity;
                if (sett.CompanyInfo.ManagerRegion != Guid.Empty)
                    cmbRegion.SelectedValue = sett.CompanyInfo.ManagerRegion;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async Task FillCmbAsync()
        {
            try
            {
                cmbType.Items.Add(EnEconomyType.Amlak.GetDisplay());
                cmbType.Items.Add(EnEconomyType.AnbouhSaz.GetDisplay());
                cmbType.Items.Add(EnEconomyType.Sayer.GetDisplay());

                token?.Cancel();
                token = new CancellationTokenSource();
                var list = await StatesBussines.GetAllAsync(token.Token);
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmEconomyUnit_Load(object sender, EventArgs e) => await SettDataAsync();

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsBussines.Setting.CompanyInfo.EconomyName = txtName.Text;
                SettingsBussines.Setting.CompanyInfo.ManagerMobile = txtMobile.Text;
                SettingsBussines.Setting.CompanyInfo.ManagerTell = txtTell.Text;
                SettingsBussines.Setting.CompanyInfo.ManagerFax = txtFax.Text;
                SettingsBussines.Setting.CompanyInfo.ManagerName = txtManagerName.Text;
                SettingsBussines.Setting.CompanyInfo.ManagerEmail = txtEmail.Text;
                if (cmbRegion.SelectedValue != null)
                    SettingsBussines.Setting.CompanyInfo.ManagerRegion = (Guid)cmbRegion.SelectedValue;
                SettingsBussines.Setting.CompanyInfo.ManagerAddress = txtAddress.Text;
                SettingsBussines.Setting.CompanyInfo.EconomyType = cmbType.Text;
                if (cmbState.SelectedValue != null)
                    SettingsBussines.Setting.CompanyInfo.EconomyState = (Guid)cmbState.SelectedValue;
                if (cmbCity.SelectedValue != null)
                    SettingsBussines.Setting.CompanyInfo.EconomyCity = (Guid)cmbCity.SelectedValue;

                await SettingsBussines.Setting.SaveAsync();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCity.SelectedValue == null) return;
                token?.Cancel();
                token = new CancellationTokenSource();
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue, token.Token);
                RegionBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbState.SelectedValue == null) return;
                token?.Cancel();
                token = new CancellationTokenSource();
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue, token.Token);
                CityBindingSource.DataSource = list.OrderBy(q => q.Name).ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmEconomyUnit_KeyDown(object sender, KeyEventArgs e)
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
    }
}
