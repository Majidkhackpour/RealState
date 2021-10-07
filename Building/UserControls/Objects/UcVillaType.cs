using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcVillaType : UserControl
    {
        public EnVillaType? VillaType
        {
            get
            {
                if (rbtnBeatch.Checked) return EnVillaType.Beatch;
                if (rbtnCity.Checked) return EnVillaType.City;
                if (rbtnForest.Checked) return EnVillaType.Forest;
                return null;
            }
            set
            {
                if (value == null) return;
                if (value == EnVillaType.Forest) rbtnForest.Checked = true;
                if (value == EnVillaType.Beatch) rbtnBeatch.Checked = true;
                if (value == EnVillaType.City) rbtnCity.Checked = true;
            }
        }
        public UcVillaType() => InitializeComponent();
    }
}
