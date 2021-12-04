using System.Windows.Forms;

namespace Building.UserControls.Contract.Sell
{
    public partial class UcContractSell_6 : UserControl
    {
        public decimal FirstDelay { get => ucFirstDelay.Price; set => ucFirstDelay.Price = value; }
        public decimal SecondDelay { get => ucSecondDelay.Price; set => ucSecondDelay.Price = value; }
        public UcContractSell_6() => InitializeComponent();
    }
}
