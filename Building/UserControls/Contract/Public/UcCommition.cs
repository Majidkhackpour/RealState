using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Public
{
    public partial class UcCommition : UserControl
    {
        public event Action<decimal> OnSumChanged;
        public string Title { set => grpPanel.Text = value; }
        public decimal TotalPrice { get => txtTotalPrice.TextDecimal; set => txtTotalPrice.TextDecimal = value; }
        public decimal Discount { get => txtDiscount.TextDecimal; set => txtDiscount.TextDecimal = value; }
        public decimal Tax { get => txtTax.TextDecimal; set => txtTax.TextDecimal = value; }
        public decimal Avarez { get => txtAvarez.TextDecimal; set => txtAvarez.TextDecimal = value; }
        public EnContractBabat Babat { get => (EnContractBabat)cmbBabat.SelectedIndex; set => cmbBabat.SelectedIndex = (int)value; }
        public decimal TotalSum => (TotalPrice + Tax + Avarez) - Discount;
        private void FillCmbBabat()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnContractBabat)).Cast<EnContractBabat>();
                foreach (var item in values)
                    cmbBabat.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void SetSallary()
        {
            try
            {
                lblSallary.Text = (TotalPrice - Discount).ToString("N0") + " ریال";
                lblTotal.Text = TotalSum.ToString("N0") + " ریال";
                RaiseSumChange(TotalSum);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void RaiseSumChange(decimal sum)
        {
            try
            {
                var handler = OnSumChanged;
                if (handler != null) OnSumChanged?.Invoke(sum);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcCommition()
        {
            InitializeComponent();
            FillCmbBabat();
        }
        private void txtDiscount_OnTextChanged()
        {
            try
            {
                SetSallary();
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtDiscount.Name) return;
                txtDiscountPercent.Text = Discount > 0 ? (Math.Round(Discount / TotalPrice, 3) * 100).ToString() : "";
                txtDiscountPercent.Text = txtDiscountPercent.Text.Replace(".", "/");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtDiscountPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtDiscountPercent.Focused) return;
                if (txtDiscountPercent.Text.ParseToDecimal() != 0)
                {
                    var d = txtDiscountPercent.Text.ParseToDecimal() / 100;
                    Discount = TotalPrice * d;
                }
                else Discount = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtTax_OnTextChanged()
        {
            try
            {
                SetSallary();
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtTax.Name) return;
                txtTaxPercent.Text = Tax > 0 ? (Math.Round(Tax / TotalPrice, 3) * 100).ToString() : "";
                txtTaxPercent.Text = txtTaxPercent.Text.Replace(".", "/");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtTaxPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtTaxPercent.Focused) return;
                if (txtTaxPercent.Text.ParseToDecimal() != 0)
                    Tax = TotalPrice * (txtTaxPercent.Text.ParseToDecimal() / 100);
                else Tax = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtAvarez_OnTextChanged()
        {
            try
            {
                SetSallary();
                var currentControl = ActiveControl?.Name;
                if (string.IsNullOrEmpty(currentControl)) return;
                if (currentControl != txtAvarez.Name) return;
                txtAvarezPercent.Text = Avarez > 0 ? (Math.Round(Avarez / TotalPrice, 3) * 100).ToString() : "";
                txtAvarezPercent.Text = txtAvarezPercent.Text.Replace(".", "/");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtAvarezPercent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtAvarezPercent.Focused) return;
                if (txtAvarezPercent.Text.ParseToDecimal() != 0)
                    Avarez = TotalPrice * (txtAvarezPercent.Text.ParseToDecimal() / 100);
                else Avarez = 0;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void txtTotalPrice_OnTextChanged() => SetSallary();
    }
}
