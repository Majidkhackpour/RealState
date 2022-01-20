using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Peoples
{
    public partial class UcPeople_BankHesab : UserControl
    {
        private List<PeoplesBankAccountBussines> _master;
        public List<PeoplesBankAccountBussines> GetBankList()=>_master ?? new List<PeoplesBankAccountBussines>();
        public void SetBankList(List<PeoplesBankAccountBussines> value)
        {
            try
            {
                if (value == null) return;
                _master = value;
                LoadBanks();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcPeople_BankHesab() => InitializeComponent();
        private void LoadBanks()
        {
            try
            {
                txtAccountNumber.Text = txtBank.Text = txtShobe.Text = "";
                bankAccountBindingSource.DataSource = GetBankList()?.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnInsBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBank.Text) ||
                    string.IsNullOrEmpty(txtAccountNumber.Text) ||
                    string.IsNullOrEmpty(txtShobe.Text)) return;
                if (GetBankList().Count <= 0) return;
                GetBankList().Add(new PeoplesBankAccountBussines()
                {
                    Guid = Guid.NewGuid(),
                    AccountNumber = txtAccountNumber.Text.Trim().FixString(),
                    BankName = txtBank.Text,
                    Shobe = txtShobe.Text
                });
                LoadBanks();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDelBank_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgBankAccount.RowCount <= 0) return;
                if (dgBankAccount.CurrentRow == null) return;
                var tagGuid = (Guid)dgBankAccount[dgBankGuid.Index, dgBankAccount.CurrentRow.Index].Value;
                var index = GetBankList().FindIndex(q => q.Guid == tagGuid);
                GetBankList().RemoveAt(index);
                LoadBanks();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void dgBankAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgBankAccount.Rows[e.RowIndex].Cells["bRadif"].Value = e.RowIndex + 1;
        }
        public async Task InitAsync()
        {
            try
            {
                var bankCollection = new AutoCompleteStringCollection();
                var banksegList = await BankSegestBussines.GetAllAsync();
                if (banksegList != null && banksegList.Count > 0)
                    bankCollection.AddRange(banksegList.Select(q => q.BankName).ToArray());

                txtBank.AutoCompleteCustomSource = bankCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtBank_Enter(object sender, EventArgs e) => txtSetter.Focus(txtBank);
        private void txtAccountNumber_Enter(object sender, EventArgs e) => txtSetter.Focus(txtAccountNumber);
        private void txtShobe_Enter(object sender, EventArgs e) => txtSetter.Focus(txtShobe);
        private void txtShobe_Leave(object sender, EventArgs e) => txtSetter.Follow(txtShobe);
        private void txtAccountNumber_Leave(object sender, EventArgs e) => txtSetter.Follow(txtAccountNumber);
        private void txtBank_Leave(object sender, EventArgs e) => txtSetter.Follow(txtBank);
    }
}
