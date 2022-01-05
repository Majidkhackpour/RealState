using System.Windows.Forms;

namespace Building.UserControls.Contract.PishForoush
{
    public partial class UcContractPishForoush_4 : UserControl
    {
        public decimal TotalPrice { get => txtTotalPrice.TextDecimal; set => txtTotalPrice.TextDecimal = value; }
        public decimal NaqdPrice { get => txtNaqdPrice.TextDecimal; set => txtNaqdPrice.TextDecimal = value; }
        public UcContractPishForoush_4() => InitializeComponent();
    }
}
