using System.Windows.Forms;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_6 : UserControl
    {
        public decimal FirstDelay { get => ucFirstDelay.Price; set => ucFirstDelay.Price = value; }
        public decimal SecondDelay { get => ucSecondDelay.Price; set => ucSecondDelay.Price = value; }
        public UcContractRahn_6() => InitializeComponent();
    }
}
