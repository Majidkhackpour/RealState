using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcTitleValue : UserControl
    {
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public string Value { get => txtValue.Text; set => txtValue.Text = value; }
        public UcTitleValue() => InitializeComponent();
    }
}
