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
    public partial class frmReceptionCheck : MetroForm
    {
        public ReceptionCheckBussines cls { get; set; }
        private void SetData()
        {
            try
            {
                txtPrice.TextDecimal = cls?.Price ?? 0;
                txtDesc.Text = cls?.Description;
                txtDate.Text = cls?.DateSarresidSh;
                txtBankName.Text = cls?.BankName;
                txtCheckNo.Text = cls?.CheckNumber;
                txtPoshtNomre.Text = cls?.PoshtNomre;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmReceptionCheck(ReceptionCheckBussines temp)
        {
            InitializeComponent();
            cls = temp ?? new ReceptionCheckBussines();
        }

        private async void frmReceptionCheck_Load(object sender, EventArgs e)
        {
            try
            {
                SetData();

                var myCollection = new AutoCompleteStringCollection();
                var list = await BankSegestBussines.GetAllAsync();
                foreach (var item in list.ToList())
                    myCollection.Add(item.BankName);
                txtBankName.AutoCompleteCustomSource = myCollection;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void frmReceptionCheck_KeyDown(object sender, KeyEventArgs e)
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
        private void txtBankName_Enter(object sender, EventArgs e) => txtSetter.Focus(txtBankName);
        private void txtCheckNo_Enter(object sender, EventArgs e) => txtSetter.Focus(txtCheckNo);
        private void txtPoshtNomre_Enter(object sender, EventArgs e) => txtSetter.Focus(txtPoshtNomre);
        private void txtPoshtNomre_Leave(object sender, EventArgs e) => txtSetter.Follow(txtPoshtNomre);
        private void txtCheckNo_Leave(object sender, EventArgs e) => txtSetter.Follow(txtCheckNo);
        private void txtBankName_Leave(object sender, EventArgs e) => txtSetter.Follow(txtBankName);
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

                if (txtPrice.TextDecimal <= 0) res.AddError("لطفا مبلغ را وارد نمایید");
                if (string.IsNullOrEmpty(txtDate.Text)) res.AddError("لطفا تاریخ سررسید چک را وارد نمایید");
                if (string.IsNullOrEmpty(txtBankName.Text)) res.AddError("لطفا بانک صادر کننده چک را وارد نمایید");
                if (string.IsNullOrEmpty(txtCheckNo.Text)) res.AddError("لطفا شماره چک را وارد نمایید");


                cls.Modified = DateTime.Now;
                cls.Status = true;
                cls.BankName = txtBankName.Text;
                cls.DateSarResid = Calendar.ShamsiToMiladi(txtDate.Text);
                cls.Description = txtDesc.Text;
                cls.CheckNumber = txtCheckNo.Text;
                cls.PoshtNomre = txtPoshtNomre.Text;
                cls.Price = txtPrice.TextDecimal;
                cls.CheckStatus = EnCheckM.Mojoud;
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
