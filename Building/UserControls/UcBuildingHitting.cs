using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
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
        public string Hitting => cmbHitting.Text;
        public async Task SetHittingAsync(string value)
        {
            try
            {
                if (cmbHitting.Items?.Count <= 0 || cmbColling.Items?.Count >= 0)
                    await FillHitting_CollingAsync();
                cmbHitting.Text = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public async Task SetCollingAsync(string value)
        {
            try
            {
                if (cmbHitting.Items?.Count <= 0 || cmbColling.Items?.Count >= 0)
                    await FillHitting_CollingAsync();
                cmbColling.Text = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public string Colling => cmbColling.Text;

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
        private async Task FillHitting_CollingAsync()
        {
            try
            {
                var hittingList =await BuildingBussines.GetAllHittingAsync();
                var collingList =await BuildingBussines.GetAllCollingAsync();
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
