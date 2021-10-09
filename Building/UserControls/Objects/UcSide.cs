using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcSide : UserControl
    {
        public EnBuildingSide? Side
        {
            get
            {
                if (cmbSide.SelectedIndex < 0) return null;
                return (EnBuildingSide?) cmbSide.SelectedIndex;
            }
            set
            {
                if (value == null) return;
                cmbSide.SelectedIndex = (int)value;
            }
        }
        public UcSide()
        {
            InitializeComponent();
            FillCmbSide();
        }
        private void FillCmbSide()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnBuildingSide)).Cast<EnBuildingSide>();
                foreach (var item in values)
                    cmbSide.Items.Add(item.GetDisplay());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
