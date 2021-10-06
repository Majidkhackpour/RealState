using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcPrice : UserControl
    {
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public decimal Price { get => txtPrice.TextDecimal; set => txtPrice.TextDecimal = value; }
        public UcPrice() => InitializeComponent();
    }
}
