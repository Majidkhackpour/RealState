using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcNumericTitleValue : UserControl
    {
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public int Value { get => (int)txtValue.Value; set => txtValue.Value = value; }
        public int DefaultValue
        {
            set
            {
                if (Value > 0) return;
                txtValue.Value = value;
            }
        }
        public UcNumericTitleValue() => InitializeComponent();
    }
}
