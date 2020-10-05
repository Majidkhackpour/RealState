using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using MetroFramework.Forms;
using Services;

namespace Advertise.Forms.MatchRegions
{
    public partial class frmMatchRegionMain : MetroForm
    {
        private DivarRegion Region;

        private async Task LoadRegionsAsync()
        {
            try
            {
                var list = await RegionsBussines.GetAllAsync((Guid.Parse(Settings.Classes.clsEconomyUnit.EconomyCity)));
                regBingingSource.DataSource = list.ToSortableBindingList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmMatchRegionMain(DivarRegion region)
        {
            InitializeComponent();
            Region = region;
        }

        private async void frmMatchRegionMain_Load(object sender, System.EventArgs e)
        {
            await LoadRegionsAsync();
            lblName.Text = Region.Name;
        }
    }
}
