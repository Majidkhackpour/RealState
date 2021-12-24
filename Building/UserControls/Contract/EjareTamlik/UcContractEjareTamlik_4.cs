using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.EjareTamlik
{
    public partial class UcContractEjareTamlik_4 : UserControl
    {
        public decimal TotalEjare { get => txtTotalEjare.TextDecimal; set => txtTotalEjare.TextDecimal = value; }
        public decimal PishPrice { get => txtPishPrice.TextDecimal; set => txtPishPrice.TextDecimal = value; }
        public string CheckNo { get => txtCheckNo1.Text; set => txtCheckNo1.Text = value; }
        public string BankName { get => txtBankName.Text; set => txtBankName.Text = value; }
        public string Shobe { get => txtShobe.Text; set => txtShobe.Text = value; }
        public UcContractEjareTamlik_4() => InitializeComponent();
        private void txtTotalEjare_OnTextChanged()
        {
            try
            {
                lblToman.Text = NumberToString.Num2Str(((double)TotalEjare / 10).ToString());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
