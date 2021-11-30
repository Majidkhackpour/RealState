using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Public
{
    public partial class UcContractCheck : UserControl
    {
        public decimal Price { get => txtPrice.TextDecimal; set => txtPrice.TextDecimal = value; }
        public string CheckNo { get => txtCheckNo.Text; set => txtCheckNo.Text = value; }
        public string BankName { get => txtBankName.Text; set => txtBankName.Text = value; }
        public string Shobe { get => txtShobe.Text; set => txtShobe.Text = value; }
        public DateTime? Sarresid
        {
            get
            {
                if (string.IsNullOrEmpty(txtDate.Text)) return null;
                return Calendar.ShamsiToMiladi(txtDate.Text);
            }
            set
            {
                if (value == null) return;
                txtDate.Text = Calendar.MiladiToShamsi(value);
            }
        }

        public UcContractCheck() => InitializeComponent();
    }
}
