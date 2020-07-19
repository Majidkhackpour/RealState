using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using PacketParser;
using PacketParser.Services;

namespace Settings
{
    public partial class frmEconomyUnit : MetroForm
    {
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

        private void SettData()
        {
            try
            {
                FillCmb();

                txtName.Text = SettingsBussines.EconomyName;
                txtMobile.Text = SettingsBussines.ManagerMobile;
                txtTell.Text = SettingsBussines.ManagerTell;
                txtFax.Text = SettingsBussines.ManagerFax;
                txtManagerName.Text = SettingsBussines.ManagerName;
                txtEmail.Text = SettingsBussines.ManagerEmail;
                txtAddress.Text = SettingsBussines.ManagerAddress;
                if (string.IsNullOrEmpty(SettingsBussines.EconomyType)) cmbType.SelectedIndex = 0;
                else
                    cmbType.Text = SettingsBussines.EconomyType;
                if (string.IsNullOrEmpty(SettingsBussines.EconomyState))
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedValue = Guid.Parse(SettingsBussines.EconomyState);
                cmbCity.SelectedValue = Guid.Parse(SettingsBussines.EconomyCity);
                cmbRegion.SelectedValue = Guid.Parse(SettingsBussines.ManagerRegion);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void FillCmb()
        {
            try
            {
                cmbType.Items.Add(EnEconomyType.Amlak.GetDisplay());
                cmbType.Items.Add(EnEconomyType.AnbouhSaz.GetDisplay());
                cmbType.Items.Add(EnEconomyType.Sayer.GetDisplay());

                var list = StatesBussines.GetAll().Where(q => q.Status).ToList();
                StateBindingSource.DataSource = list.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private void frmEconomyUnit_Load(object sender, EventArgs e)
        {
            SettData();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsBussines.EconomyName = txtName.Text;
                SettingsBussines.ManagerMobile = txtMobile.Text;
                SettingsBussines.ManagerTell = txtTell.Text;
                SettingsBussines.ManagerFax = txtFax.Text;
                SettingsBussines.ManagerName = txtManagerName.Text;
                SettingsBussines.ManagerEmail = txtEmail.Text;
                SettingsBussines.ManagerRegion = cmbRegion.SelectedValue.ToString();
                SettingsBussines.ManagerAddress = txtAddress.Text;
                SettingsBussines.EconomyType = cmbType.Text;
                SettingsBussines.EconomyState = cmbState.SelectedValue.ToString();
                SettingsBussines.EconomyCity = cmbCity.SelectedValue.ToString();

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
                var list = await RegionsBussines.GetAllAsync((Guid)cmbCity.SelectedValue);
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
                var list = await CitiesBussines.GetAllAsync((Guid)cmbState.SelectedValue);
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
