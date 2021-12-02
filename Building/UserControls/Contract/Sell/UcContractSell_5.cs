using System.Windows.Forms;

namespace Building.UserControls.Contract.Sell
{
    public partial class UcContractSell_5 : UserControl
    {
        public string DischargeDateSh { set => lblContractDate.Text = value; }
        public decimal AmountOfRent { get => txtAmountOfRent.TextDecimal; set => txtAmountOfRent.TextDecimal = value; }
        public UcContractSell_5() => InitializeComponent();
    }
}
