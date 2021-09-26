using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Notification;
using Services;

namespace Peoples
{
    public partial class frmPeoples : MetroForm
    {
        private PeoplesBussines cls;
        public Guid SelectedGuid { get; set; }
        private List<Guid> _groupList;

        private async Task SetDataAsync()
        {
            try
            {
                SetAccess();
                await LoadGroups();
                LoadTells();
                LoadBanks();
                FillCmbPrice();
                SetTxtPrice();
                await FillPhoneBookTitleAsync();
                await LoadSubGroups(cls?.GroupGuid ?? Guid.Empty);

                txtCode.Text = cls?.Code;
                txtNationalCode.Text = cls?.NationalCode;
                txtName.Text = cls?.Name;
                txtIdCode.Text = cls?.IdCode;
                txtFatherName.Text = cls?.FatherName;
                txtPlaceBirth.Text = cls?.PlaceBirth;
                txtIssuesFrom.Text = cls?.IssuedFrom;
                txtPostalCode.Text = cls?.PostalCode;
                txtAddress.Text = cls?.Address;
                txtDateBirth.Text = cls?.DateBirth;

                if (cls?.Guid == Guid.Empty)
                {
                    await NextCodeAsync();
                    cmbGroup.SelectedIndex = 1;
                }
                else
                {
                    if (_groupList.Contains(cls.GroupGuid))
                    {
                        cmbGroup.SelectedValue = cls.GroupGuid;
                        await LoadSubGroups(cls.GroupGuid);
                    }
                    else
                    {
                        var grp = await PeopleGroupBussines.GetAsync(cls.GroupGuid);
                        if (grp == null) return;
                        cmbGroup.SelectedValue = grp.ParentGuid;
                        cmbSubGroup.SelectedValue = cls.GroupGuid;
                    }
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task NextCodeAsync()
        {
            try
            {
                txtCode.Text = await TafsilBussines.NextCodeAsync(HesabType.Customer);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadGroups()
        {
            try
            {
                var list = await PeopleGroupBussines.GetAllAsync();
                list = list?.Where(q => q.Status && q.ParentGuid == Guid.Empty)?.OrderBy(q => q.Name)?.ToList();
                groupBundingSource.DataSource = list;
                _groupList = list?.Select(q => q.Guid)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task LoadSubGroups(Guid parentGuid)
        {
            try
            {
                if (parentGuid == Guid.Empty)
                {
                    subGroupBingingSource.DataSource = null;
                    return;
                }
                var list = await PeopleGroupBussines.GetAllAsync(parentGuid);
                list = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
                subGroupBingingSource.DataSource = list;

                if (!_groupList.Contains(cls.GroupGuid))
                {
                    var grp = await PeopleGroupBussines.GetAsync(cls.GroupGuid);
                    if (grp == null) return;
                    //cmbGroup.SelectedValue = grp.ParentGuid;
                    cmbSubGroup.SelectedValue = cls.GroupGuid;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadTells()
        {
            try
            {
                txtTell.Text = "";
                cmbTitles.Text = "";
                phoneBookBindingSource.DataSource = cls?.TellList?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void LoadBanks()
        {
            try
            {
                txtAccountNumber.Text = txtBank.Text = txtShobe.Text = "";
                bankAccountBindingSource.DataSource = cls?.BankList?.ToList();
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
        private void SetAccess()
        {
            try
            {
                txtAccount_.Visible = VersionAccess.Accounting;
                cmbAccount.Visible = VersionAccess.Accounting;
                label16.Visible = VersionAccess.Accounting;
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
                if (cls?.AccountFirst == 0)
                {
                    txtAccount_.TextDecimal = cls?.AccountFirst ?? 0;
                    cmbAccount.SelectedIndex = 0;
                }

                if (cls?.AccountFirst < 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 1;
                }

                if (cls?.AccountFirst > 0)
                {
                    txtAccount_.TextDecimal = Math.Abs(cls?.AccountFirst ?? 0);
                    cmbAccount.SelectedIndex = 2;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillPhoneBookTitleAsync()
        {
            try
            {
                var list = await PhoneBookBussines.GetAllTitlesAsync();
                cmbTitles.Items.Clear();
                if (list == null || list.Count <= 0) return;
                cmbTitles.Items.AddRange(list.ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmPeoples()
        {
            InitializeComponent();
            cls = new PeoplesBussines();
            ucHeader.Text = "افزودن شخص جدید";
            ucHeader.IsModified = cls.IsModified;
            superTabControl1.SelectedTab = superTabItem1;
            WindowState = FormWindowState.Maximized;
        }
        public frmPeoples(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = PeoplesBussines.Get(guid,null);
            ucHeader.Text = !isShowMode ? $"ویرایش {cls.Name}" : $"مشاهده {cls.Name}";
            ucHeader.IsModified = cls.IsModified;
            superTabControlPanel1.Enabled = !isShowMode;
            superTabControlPanel2.Enabled = !isShowMode;
            superTabControlPanel3.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
            superTabControl1.SelectedTab = superTabItem1;
            WindowState = FormWindowState.Maximized;
        }

        private async void frmPeoples_Load(object sender, EventArgs e)
        {
            try
            {
                await SetDataAsync();

                var nameCollection = new AutoCompleteStringCollection();
                var fNameCollection = new AutoCompleteStringCollection();
                var bankCollection = new AutoCompleteStringCollection();
                var shobeCollection = new AutoCompleteStringCollection();
                var nCodeCollection = new AutoCompleteStringCollection();
                var placeCollection = new AutoCompleteStringCollection();
                var issuedCollection = new AutoCompleteStringCollection();
                var list = await PeoplesBussines.GetAllAsync(new CancellationToken());
                foreach (var item in list.ToList())
                {
                    nameCollection.Add(item.Name);
                    fNameCollection.Add(item.FatherName);
                    placeCollection.Add(item.PlaceBirth);
                    issuedCollection.Add(item.IssuedFrom);
                    nCodeCollection.Add(item.NationalCode);
                }

                var banksegList = await BankSegestBussines.GetAllAsync();
                if (banksegList != null && banksegList.Count > 0)
                    bankCollection.AddRange(banksegList.Select(q => q.BankName).ToArray());

                txtName.AutoCompleteCustomSource = nameCollection;
                txtFatherName.AutoCompleteCustomSource = fNameCollection;
                txtNationalCode.AutoCompleteCustomSource = nCodeCollection;
                txtPlaceBirth.AutoCompleteCustomSource = placeCollection;
                txtIssuesFrom.AutoCompleteCustomSource = issuedCollection;
                txtShobe.AutoCompleteCustomSource = shobeCollection;
                txtBank.AutoCompleteCustomSource = bankCollection;
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
        private void txtTell_Enter(object sender, EventArgs e) => txtSetter.Focus(txtTell);
        private void txtBank_Enter(object sender, EventArgs e) => txtSetter.Focus(txtBank);
        private void txtAccountNumber_Enter(object sender, EventArgs e) => txtSetter.Focus(txtAccountNumber);
        private void txtShobe_Enter(object sender, EventArgs e) => txtSetter.Focus(txtShobe);
        private void txtShobe_Leave(object sender, EventArgs e) => txtSetter.Follow(txtShobe);
        private void txtAccountNumber_Leave(object sender, EventArgs e) => txtSetter.Follow(txtAccountNumber);
        private void txtBank_Leave(object sender, EventArgs e) => txtSetter.Follow(txtBank);
        private void txtTell_Leave(object sender, EventArgs e) => txtSetter.Follow(txtTell);
        private void txtPostalCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPostalCode);
        private void txtIssuesFrom_Leave(object sender, EventArgs e) => txtSetter.Follow(txtIssuesFrom);
        private void txtPlaceBirth_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPlaceBirth);
        private void txtFatherName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtFatherName);
        private void txtIdCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtIdCode);
        private void txtCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCode);
        private void txtNationalCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtNationalCode);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmPeoples_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        if (txtShobe.Focused)
                        {
                            btnInsBank.PerformClick();
                            txtBank.Focus();
                            return;
                        }

                        if (txtTell.Focused)
                        {
                            btnInsTell.PerformClick();
                            return;
                        }

                        if (!btnFinish.Focused && !btnCancel.Focused && !txtAddress.Focused)
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
        private async void btnInsTell_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTell.Text)) return;
                if (cls.TellList == null) cls.TellList = new List<PhoneBookBussines>();
                foreach (var item in cls.TellList)
                    if (txtTell.Text.Trim() == item.Tell) return;
                cls.TellList.Add(new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Tell = txtTell.Text,
                    Group = EnPhoneBookGroup.Peoples,
                    Name = txtName.Text,
                    Title = cmbTitles.Text
                });
                LoadTells();
                await FillPhoneBookTitleAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void btnDelTell_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGridTell.RowCount <= 0) return;
                if (DGridTell.CurrentRow == null) return;
                var tagGuid = (Guid)DGridTell[dgTellGuid.Index, DGridTell.CurrentRow.Index].Value;
                var index = cls.TellList.FindIndex(q => q.Guid == tagGuid);
                cls.TellList.RemoveAt(index);
                LoadTells();
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
                if (cls.BankList == null) cls.BankList = new List<PeoplesBankAccountBussines>();
                cls.BankList.Add(new PeoplesBankAccountBussines()
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
                var index = cls.BankList.FindIndex(q => q.Guid == tagGuid);
                cls.BankList.RemoveAt(index);
                LoadBanks();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void DGridTell_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DGridTell.Rows[e.RowIndex].Cells["tRadif"].Value = e.RowIndex + 1;
        }
        private void dgBankAccount_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgBankAccount.Rows[e.RowIndex].Cells["bRadif"].Value = e.RowIndex + 1;
        }
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                    cls.Guid = Guid.NewGuid();

                cls.Name = txtName.Text.Trim();
                cls.Modified = DateTime.Now;
                cls.Code = txtCode.Text.Trim();
                cls.NationalCode = txtNationalCode.Text.Trim();
                cls.IdCode = txtIdCode.Text.Trim();
                cls.FatherName = txtFatherName.Text;
                if (cmbSubGroup.SelectedValue == null)
                    cls.GroupGuid = (Guid)cmbGroup.SelectedValue;
                else cls.GroupGuid = (Guid)cmbSubGroup.SelectedValue;
                cls.PlaceBirth = txtPlaceBirth.Text;
                cls.DateBirth = txtDateBirth.Text;
                cls.IssuedFrom = txtIssuesFrom.Text;
                cls.PostalCode = txtPostalCode.Text;
                cls.Address = txtAddress.Text;
                var acc = txtAccount_.TextDecimal;
                if (cmbAccount.SelectedIndex == 1) cls.AccountFirst = -acc;
                else cls.AccountFirst = acc;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                res.AddReturnedValue(exception);
            }
            finally
            {
                if (res.HasError) this.ShowError(res, "خطا در ثبت شخص");
                else
                {
                    SelectedGuid = cls.Guid;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void txtBank_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Space)
                e.Handled = true;
        }
        private async void cmbGroup_SelectedIndexChanged(object sender, EventArgs e) => await LoadSubGroups((Guid)cmbGroup.SelectedValue);
    }
}
