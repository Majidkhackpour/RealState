using System.Windows.Forms;

namespace Building.UserControls.Contract.Sarqofli
{
    public partial class UcContractSarqofli_6 : UserControl
    {
        public decimal AmountOfRent { get => txtAmountOfRent.TextDecimal; set => txtAmountOfRent.TextDecimal = value; }
        public string GulidType { get => txtGulidType.Text; set => txtGulidType.Text = value; }
        public UcContractSarqofli_6() => InitializeComponent();
    }
}
