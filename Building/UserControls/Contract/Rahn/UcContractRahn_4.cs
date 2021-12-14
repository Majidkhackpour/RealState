using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_4 : UserControl
    {
        public decimal Ejare { get => txtMinorPrice.TextDecimal; set => txtMinorPrice.TextDecimal = value; }
        public decimal Rahn { get => txtMajorPrice.TextDecimal; set => txtMajorPrice.TextDecimal = value; }
        public decimal TotalPrice { get => txtTotalPrice.TextDecimal; set => txtTotalPrice.TextDecimal = value; }
        public string CheckNoFrom { get => txtCheckNo1.Text; set => txtCheckNo1.Text = value; }
        public string CheckNoTo { get => txtCheckNo2.Text; set => txtCheckNo2.Text = value; }
        public DateTime? SarresidFrom
        {
            get
            {
                if (string.IsNullOrEmpty(txtDate1.Text)) return null;
                return Calendar.ShamsiToMiladi(txtDate1.Text);
            }
            set
            {
                if (value == null) return;
                txtDate1.Text = Calendar.MiladiToShamsi(value);
            }
        }
        public DateTime? SarresidTo
        {
            get
            {
                if (string.IsNullOrEmpty(txtDate2.Text)) return null;
                return Calendar.ShamsiToMiladi(txtDate2.Text);
            }
            set
            {
                if (value == null) return;
                txtDate2.Text = Calendar.MiladiToShamsi(value);
            }
        }
        public string BankName { get => txtBankName.Text; set => txtBankName.Text = value; }
        public string Shobe { get => txtShobe.Text; set => txtShobe.Text = value; }
        public int Term { set => TotalPrice = value * Ejare; }
        public UcContractRahn_4() => InitializeComponent();
        private void txtMajorPrice_OnTextChanged()
        {
            try
            {
                lblToman.Text = NumberToString.Num2Str(((double)Rahn / 10).ToString());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
