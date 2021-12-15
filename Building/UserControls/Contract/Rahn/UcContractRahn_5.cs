using System.Windows.Forms;

namespace Building.UserControls.Contract.Rahn
{
    public partial class UcContractRahn_5 : UserControl
    {
        public string DischargeDateSh { set => lblContractDate.Text = value; }
        public int PeopleCount { get => (int) txtPeopleCount.Value; set => txtPeopleCount.Value = value; }
        public UcContractRahn_5() => InitializeComponent();
    }
}
