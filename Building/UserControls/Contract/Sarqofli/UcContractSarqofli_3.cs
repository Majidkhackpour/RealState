using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Sarqofli
{
    public partial class UcContractSarqofli_3 : UserControl
    {
        public decimal Price { get => txtPrice.TextDecimal; set => txtPrice.TextDecimal = value; }
        public decimal Naqd { get => txtNaqd.TextDecimal; set => txtNaqd.TextDecimal = value; }
        public decimal CheckPrice { get => ucContractCheck1.Price; set => ucContractCheck1.Price = value; }
        public string BankName { get => ucContractCheck1.BankName; set => ucContractCheck1.BankName = value; }
        public string CheckNo { get => ucContractCheck1.CheckNo; set => ucContractCheck1.CheckNo = value; }
        public string Shobe { get => ucContractCheck1.Shobe; set => ucContractCheck1.Shobe = value; }
        public DateTime? Sarresid { get => ucContractCheck1.Sarresid; set => ucContractCheck1.Sarresid = value; }
        public UcContractSarqofli_3() => InitializeComponent();
        private void txtPrice_OnTextChanged()
        {
            try
            {
                lblToman.Text = NumberToString.Num2Str(((double)txtPrice.TextDecimal / 10).ToString());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
