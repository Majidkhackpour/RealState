using System;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Accounting.Bank
{
    public partial class frmBankMain : MetroForm
    {
        private BankBussines cls;
        private void SetData()
        {
            try
            {
                txtName.Text = cls?.Name;
                txtDesc.Text = cls?.Description;
                txtCodeShobe.Text = cls?.CodeShobe;
                txtShobe.Text = cls?.Shobe;
                txtHesabNumber.Text = cls?.HesabNumber;
                txtCode.Text = cls.Guid == Guid.Empty ? NextCode() : cls?.Code;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private string NextCode()
        {
            var res = "";
            try
            {
                res = TafsilBussines.NextCode(HesabType.Bank);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }

        public frmBankMain()
        {
            InitializeComponent();
            cls = new BankBussines();
        }
        public frmBankMain(Guid guid, bool isShowMode)
        {
            InitializeComponent();
            cls = BankBussines.Get(guid);
            grp.Enabled = !isShowMode;
            btnFinish.Enabled = !isShowMode;
        }

        private void frmBankMain_Load(object sender, EventArgs e) => SetData();
        private void txtCode_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCode);
        private void txtName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtName);
        private void txtShobe_Enter(object sender, EventArgs e) => txtSetter.Focus(txtShobe);
        private void txtCodeShobe_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCodeShobe);
        private void txtHesabNumber_Enter(object sender, EventArgs e) => txtSetter.Focus(txtHesabNumber);
        private void txtCode_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCode);
        private void txtName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtName);
        private void txtShobe_Leave(object sender, EventArgs e) => txtSetter.Follow(txtShobe);
        private void txtCodeShobe_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCodeShobe);
        private void txtHesabNumber_Leave(object sender, EventArgs e) => txtSetter.Follow(txtHesabNumber);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void frmBankMain_KeyDown(object sender, KeyEventArgs e)
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
        private async void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                }
                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.Name = txtName.Text;
                cls.Code = txtCode.Text;
                cls.Description = txtDesc.Text;
                cls.Shobe = txtShobe.Text;
                cls.CodeShobe = txtCodeShobe.Text;
                cls.HesabNumber = txtHesabNumber.Text;

                res.AddReturnedValue(await cls.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت حساب بانکی");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
