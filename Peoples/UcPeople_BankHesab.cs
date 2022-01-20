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
        public List<PeoplesBankAccountBussines> BankList
        {
            get => _master ?? new List<PeoplesBankAccountBussines>();
            set
            {
                _master = value;
                LoadBanks();
            }
        }
        public UcPeople_BankHesab() => InitializeComponent();
        private void LoadBanks()
        {
            try
            {
                txtAccountNumber.Text = txtBank.Text = txtShobe.Text = "";
                bankAccountBindingSource.DataSource = BankList?.ToSortableBindingList();
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
                if (BankList.Count <= 0) return;
                BankList.Add(new PeoplesBankAccountBussines()
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
                var index = BankList.FindIndex(q => q.Guid == tagGuid);
                BankList.RemoveAt(index);
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
