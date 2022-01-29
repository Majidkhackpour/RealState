using System.Drawing;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingDetail_Detail : UserControl
    {
        public string Title { get => lblTitle.Text; set => lblTitle.Text = value; }
        public string Value { get => lblValue.Text; set => lblValue.Text = value; }
        public Image Png { get => pictureBox1.Image; set => pictureBox1.Image = value; }
        public UcBuildingDetail_Detail() => InitializeComponent();
    }
}
