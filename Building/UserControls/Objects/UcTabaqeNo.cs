using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcTabaqeNo : UserControl
    {
        public int TabaqeNo { get => cmbTabaqeNo.Text.ParseToInt(); set => cmbTabaqeNo.SelectedIndex = value + 3; }
        public UcTabaqeNo() => InitializeComponent();
    }
}
