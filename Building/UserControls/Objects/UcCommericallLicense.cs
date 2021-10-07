using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcCommericallLicense : UserControl
    {
        public EnCommericallLicense? CommericallLicense
        {
            get
            {
                if (rbtnDaemi.Checked) return EnCommericallLicense.Permament;
                if (rbtnNone.Checked) return EnCommericallLicense.HasNot;
                if (rbtnTemporary.Checked) return EnCommericallLicense.Temporary;
                return null;
            }
            set
            {
                if (value == null) return;
                if (value == EnCommericallLicense.HasNot) rbtnNone.Checked = true;
                if (value == EnCommericallLicense.Permament) rbtnDaemi.Checked = true;
                if (value == EnCommericallLicense.Temporary) rbtnTemporary.Checked = true;
            }
        }
        public UcCommericallLicense() => InitializeComponent();
    }
}
