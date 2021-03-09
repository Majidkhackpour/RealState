using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using Services.DefaultCoding;

namespace Accounting.Reception
{
    public partial class frmReceptionHavale : MetroForm
    {
        public ReceptionHavaleBussines cls { get; set; }
        private async Task SetDataAsync()
        {
            try
            {
                await FillBankAsync();

                txtPrice.TextDecimal = cls?.Price ?? 0;
                txtDesc.Text = cls?.Description;
                txtPeygiriNo.Text = cls?.PeygiriNumber;

                if (cls.Guid == Guid.Empty && BankBindingSource.Count > 0) cmbBank.SelectedIndex = 0;
                else cmbBank.SelectedValue = cls.BankTafsilGuid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBankAsync()
        {
            try
            {
                var list = await TafsilBussines.GetAllAsync("", HesabType.Bank);
                BankBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmReceptionHavale(ReceptionHavaleBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new ReceptionHavaleBussines();
        }

        private async void frmReceptionHavale_Load(object sender, EventArgs e) => await SetDataAsync();
        private void frmReceptionHavale_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPeygiriNo_Enter(object sender, EventArgs e) => txtSetter.Focus(txtPeygiriNo);
        private void txtPeygiriNo_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPeygiriNo);
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (cls.Guid == Guid.Empty)
                {
                    cls.Guid = Guid.NewGuid();
                    cls.DateM = DateTime.Now;
                }

                if (BankBindingSource.Count <= 0) res.AddError("لطفا صندوق مقصد را انتخاب نمایید");
                if (txtPrice.TextDecimal <= 0) res.AddError("لطفا مبلغ را وارد نمایید");

                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.PeygiriNumber = txtPeygiriNo.Text;
                cls.Description = txtDesc.Text;
                cls.BankTafsilGuid = (Guid)cmbBank.SelectedValue;
                cls.Price = txtPrice.TextDecimal;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (res.HasError)
                    this.ShowError(res, "خطا در ثبت دریافت حواله");
                else
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
