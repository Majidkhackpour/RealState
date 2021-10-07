using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcTarakom : UserControl
    {
        public EnTarakom? Tarakom
        {
            get
            {
                if (rbtnHigh.Checked) return EnTarakom.High;
                if (rbtnLow.Checked) return EnTarakom.Low;
                if (rbtnMedium.Checked) return EnTarakom.Min;
                return null;
            }
            set
            {
                if (value == null) return;
                if (value == EnTarakom.High) rbtnHigh.Checked = true;
                if (value == EnTarakom.Low) rbtnLow.Checked = true;
                if (value == EnTarakom.Min) rbtnMedium.Checked = true;
            }
        }
        public UcTarakom() => InitializeComponent();
    }
}
