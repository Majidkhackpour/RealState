using System;
using System.Linq;
using System.Windows.Forms;
using Services;

namespace Building.UserControls
{
    public partial class UcBuildingHitting : UserControl
    {
        public EnKhadamati Water
        {
            get => (EnKhadamati) cmbWater.SelectedIndex;
            set
            {
                if ((int) value < 0) return;
                cmbWater.SelectedIndex = (int) value;
            }
        }
        public EnKhadamati Barq
        {
            get => (EnKhadamati)cmbBarq.SelectedIndex;
            set
            {
                if ((int)value < 0) return;
                cmbBarq.SelectedIndex = (int)value;
            }
        }
        public EnKhadamati Gas
        {
            get => (EnKhadamati)cmbGas.SelectedIndex;
            set
            {
                if ((int)value < 0) return;
                cmbGas.SelectedIndex = (int)value;
            }
        }
        public EnKhadamati Tell
        {
            get => (EnKhadamati)cmbTell.SelectedIndex;
            set
            {
                if ((int)value < 0) return;
                cmbTell.SelectedIndex = (int)value;
            }
        }

        public UcBuildingHitting()
        {
            InitializeComponent();
            FillCmbKhadamt();
        }
        private void FillCmbKhadamt()
        {
            try
            {
                var values = Enum.GetValues(typeof(EnKhadamati)).Cast<EnKhadamati>();
                foreach (var item in values)
                {
                    cmbWater.Items.Add(item.GetDisplay());
                    cmbGas.Items.Add(item.GetDisplay());
                    cmbBarq.Items.Add(item.GetDisplay());
                    cmbTell.Items.Add(item.GetDisplay());
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
