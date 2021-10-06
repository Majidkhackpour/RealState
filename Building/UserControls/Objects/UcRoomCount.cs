using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcRoomCount : UserControl
    {
        public int RoomCount { get => cmbRoomCount.SelectedIndex; set => cmbRoomCount.SelectedIndex = value; }
        public UcRoomCount() => InitializeComponent();
    }
}
