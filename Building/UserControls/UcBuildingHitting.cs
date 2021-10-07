using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingHitting : UserControl
    {
        public EnKhadamati? Water
        {
            get => (EnKhadamati)cmbWater.SelectedIndex;
            set
            {
                if (value == null || (int)value < 0) return;
                cmbWater.SelectedIndex = (int)value;
            }
        }
        public EnKhadamati? Barq
        {
            get => (EnKhadamati)cmbBarq.SelectedIndex;
            set
            {
                if (value == null || (int)value < 0) return;
                cmbBarq.SelectedIndex = (int)value;
            }
        }
        public EnKhadamati? Gas
        {
            get => (EnKhadamati)cmbGas.SelectedIndex;
            set
            {
                if (value == null || (int)value < 0) return;
                cmbGas.SelectedIndex = (int)value;
            }
        }
        public EnKhadamati? Tell
        {
            get => (EnKhadamati)cmbTell.SelectedIndex;
            set
            {
                if (value == null || (int)value < 0) return;
                cmbTell.SelectedIndex = (int)value;
            }
        }
        public string Hitting { get => cmbHitting.Text; set => cmbHitting.Text = value; }
        public string Colling { get => cmbColling.Text; set => cmbColling.Text = value; }

        public UcBuildingHitting()
        {
            InitializeComponent();
            FillCmbKhadamt();
            FillHitting_Colling();
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
        private void FillHitting_Colling()
        {
            try
            {
                var hittingList = BuildingBussines.GetAllHitting();
                var collingList = BuildingBussines.GetAllColling();
                cmbHitting.Items.Clear();
                cmbColling.Items.Clear();
                if (hittingList != null && hittingList.Count > 0)
                    cmbHitting.Items.AddRange(hittingList.ToArray());
                if (collingList != null && collingList.Count > 0)
                    cmbColling.Items.AddRange(collingList.ToArray());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
