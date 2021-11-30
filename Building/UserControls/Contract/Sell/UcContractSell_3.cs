using System;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Contract.Sell
{
    public partial class UcContractSell_3 : UserControl
    {
        public decimal Price
        {
            get => txtPrice.TextDecimal;
            set
            {
                txtPrice.TextDecimal = value;
                lblDigit.Text =$"{NumberToString.Num2Str(((double)value).ToString())} ریال";
                lblToman.Text = NumberToString.Num2Str(((double)value / 10).ToString());
            }
        }
        public decimal Naqd { get => txtNaqd.TextDecimal; set => txtNaqd.TextDecimal = value; }
        public decimal CheckPrice1 { get => ucContractCheck1.Price; set => ucContractCheck1.Price = value; }
        public decimal CheckPrice2 { get => ucContractCheck2.Price; set => ucContractCheck2.Price = value; }
        public string BankName1 { get => ucContractCheck1.BankName; set => ucContractCheck1.BankName = value; }
        public string BankName2 { get => ucContractCheck2.BankName; set => ucContractCheck2.BankName = value; }
        public string CheckNo1 { get => ucContractCheck1.CheckNo; set => ucContractCheck1.CheckNo = value; }
        public string CheckNo2 { get => ucContractCheck2.CheckNo; set => ucContractCheck2.CheckNo = value; }
        public string Shobe1 { get => ucContractCheck1.Shobe; set => ucContractCheck1.Shobe = value; }
        public string Shobe2 { get => ucContractCheck2.Shobe; set => ucContractCheck2.Shobe = value; }
        public DateTime? Sarresid1 { get => ucContractCheck1.Sarresid; set => ucContractCheck1.Sarresid = value; }
        public DateTime? Sarresid2 { get => ucContractCheck2.Sarresid; set => ucContractCheck2.Sarresid = value; }
        public UcContractSell_3() => InitializeComponent();
    }
}
