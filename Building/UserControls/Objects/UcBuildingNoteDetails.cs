using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingNoteDetails : UserControl
    {
        public string Note { get => lblDesc.Text; set => lblDesc.Text = value; }
        public UcBuildingNoteDetails() => InitializeComponent();
    }
}
