using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;
using Settings.Classes;

namespace Settings.SettingForms
{
    public partial class frmEconomy : Form
    {
        public frmEconomy()
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

        private void txtName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtName);
        }

        private void txtMobile_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtMobile);
        }

        private void txtMobile_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtMobile);
        }

        private void txtManagerName_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtManagerName);
        }

        private void txtManagerName_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtManagerName);
        }

        private void txtTell_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtTell);
        }

        private void txtTell_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtTell);
        }

        private void txtFax_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtFax);
        }

        private void txtFax_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtFax);
        }

        private void txtEmail_Enter(object sender, System.EventArgs e)
        {
            txtSetter.Focus(txtEmail);
        }

        private void txtEmail_Leave(object sender, System.EventArgs e)
        {
            txtSetter.Follow(txtEmail);
        }
        #endregion
        private async Task SettDataAsync()
        {
            try
            {
                await FillCmbAsync();

                txtName.Text = clsEconomyUnit.EconomyName;
                txtMobile.Text = clsEconomyUnit.ManagerMobile;
                txtTell.Text = clsEconomyUnit.ManagerTell;
                txtFax.Text = clsEconomyUnit.ManagerFax;
                txtManagerName.Text = clsEconomyUnit.ManagerName;
                txtEmail.Text = clsEconomyUnit.ManagerEmail;
                txtAddress.Text = clsEconomyUnit.ManagerAddress;
                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyType)) cmbType.SelectedIndex = 0;
                else
                    cmbType.Text = clsEconomyUnit.EconomyType;
                if (string.IsNullOrEmpty(clsEconomyUnit.EconomyState))
                    cmbState.SelectedIndex = 0;
                else
                    cmbState.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyState);
                cmbCity.SelectedValue = Guid.Parse(clsEconomyUnit.EconomyCity);
                cmbRegion.SelectedValue = Guid.Parse(clsEconomyUnit.ManagerRegion);
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

                var list = await StatesBussines.GetAllAsync();
                StateBindingSource.DataSource = list.Where(q => q.Status).OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        private async void frmEconomy_Load(object sender, EventArgs e) => await SettDataAsync();

        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                clsEconomyUnit.EconomyName = txtName.Text;
                clsEconomyUnit.ManagerMobile = txtMobile.Text;
                clsEconomyUnit.ManagerTell = txtTell.Text;
                clsEconomyUnit.ManagerFax = txtFax.Text;
                clsEconomyUnit.ManagerName = txtManagerName.Text;
                clsEconomyUnit.ManagerEmail = txtEmail.Text;
                clsEconomyUnit.ManagerRegion = cmbRegion.SelectedValue?.ToString() ?? Guid.NewGuid().ToString();
                clsEconomyUnit.ManagerAddress = txtAddress.Text;
                clsEconomyUnit.EconomyType = cmbType.Text;
                clsEconomyUnit.EconomyState = cmbState.SelectedValue.ToString();
                clsEconomyUnit.EconomyCity = cmbCity.SelectedValue.ToString();


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
    }
}
