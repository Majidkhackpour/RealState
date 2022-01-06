using System.Windows.Forms;

namespace Building.UserControls.Contract.PishForoush
{
    public partial class UcContractPishForoush_8 : UserControl
    {
        public string DocumentAdjustment { get => txtDocAdjust.Text; set => txtDocAdjust.Text = value; }
        public UcContractPishForoush_8() => InitializeComponent();
    }
}
