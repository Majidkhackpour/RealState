using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Peoples
{
    public partial class UcPeople_PublicInfo : UserControl
    {
        private decimal _firstAccount = 0;
        public string Code { get => txtCode.Text; set => txtCode.Text = value; }
        public string NationalCode { get => txtNationalCode.Text; set => txtNationalCode.Text = value; }
        public string ObjectName { get => txtName.Text; set => txtName.Text = value; }
        public string IdCode { get => txtIdCode.Text; set => txtIdCode.Text = value; }
        public string FatherName { get => txtFatherName.Text; set => txtFatherName.Text = value; }
        public string BirthPlace { get => txtPlaceBirth.Text; set => txtPlaceBirth.Text = value; }
        public string BirthDate { get => txtDateBirth.Text; set => txtDateBirth.Text = value; }
        public string IssuedFrom { get => txtIssuesFrom.Text; set => txtIssuesFrom.Text = value; }
        public string PostalCode { get => txtPostalCode.Text; set => txtPostalCode.Text = value; }
        public string Address { get => txtAddress.Text; set => txtAddress.Text = value; }
        public decimal AccountFirst
        {
            get
            {
                var acc = txtAccount_.TextDecimal;
                if (cmbAccount.SelectedIndex == 1) _firstAccount = -acc;
                else _firstAccount = acc;
                return _firstAccount;
            }
            set
            {
                _firstAccount = value;
                SetTxtPrice();
            }
        }
        public Guid GroupGuid
        {
            get
            {
                if (cmbGroup.SelectedValue == null) return Guid.Empty;
                return (Guid)cmbGroup.SelectedValue;
            }
        }
        public UcPeople_PublicInfo()
        {
            InitializeComponent();
            FillCmbPrice();
        }
        private async Task LoadGroupsAsync()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                list = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
                groupBundingSource.DataSource = list;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillCmbPrice()
        {
            try
            {
                cmbAccount.Items.Add(EnAccountType.BiHesab.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bed.GetDisplay());
                cmbAccount.Items.Add(EnAccountType.Bes.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public async Task SetGroupGuidAsync(Guid value)
        {
            try
            {
                if (groupBundingSource.Count <= 0)
                    await LoadGroupsAsync();
                if (value == Guid.Empty) return;
                cmbGroup.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public void SetAccess(bool hasAccounting)
        {
            try
            {
                txtAccount_.Visible = hasAccounting;
                cmbAccount.Visible = hasAccounting;
                label16.Visible = hasAccounting;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetTxtPrice()
        {
            try
            {
                if (_firstAccount == 0)
                {
                    txtAccount_.TextDecimal = _firstAccount ;
                    cmbAccount.SelectedIndex = 0;
                }

                if (_firstAccount < 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(_firstAccount);
                    cmbAccount.SelectedIndex = 1;
                }

                if (_firstAccount > 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(_firstAccount);
                    cmbAccount.SelectedIndex = 2;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCode);
        private void txtNationalCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtNationalCode);
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtIdCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtIdCode);
        private void txtFatherName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtFatherName);
        private void txtPlaceBirth_Enter(object sender, EventArgs e) => txtSetter.Focus(txtPlaceBirth);
        private void txtIssuesFrom_Enter(object sender, EventArgs e) => txtSetter.Focus(txtIssuesFrom);
        private void txtPostalCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtPostalCode);
        private void txtPostalCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPostalCode);
        private void txtIssuesFrom_Leave(object sender, EventArgs e) => txtSetter.Follow(txtIssuesFrom);
        private void txtPlaceBirth_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPlaceBirth);
        private void txtFatherName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtFatherName);
        private void txtIdCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtIdCode);
        private void txtCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCode);
        private void txtNationalCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtNationalCode);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
    }
}
