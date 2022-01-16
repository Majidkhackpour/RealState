using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Contract.PishForoush
{
    public partial class UcContractPishForoush_10 : UserControl
    {
        private async Task LoadCityAsync()
        {
            try
            {
                var cityGuid = Settings.Classes.clsEconomyUnit.EconomyCity;
                if (string.IsNullOrEmpty(cityGuid)) return;
                var cGuid = Guid.Parse(cityGuid);
                if (cGuid == Guid.Empty) return;
                var city = await CitiesBussines.GetAsync(cGuid);
                if (city == null) return;
                while (!IsHandleCreated) { await Task.Delay(100); }
                BeginInvoke(new MethodInvoker(() => lblCity.Text = city.Name));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcContractPishForoush_10()
        {
            InitializeComponent();
            lblCity.Text = "";
            _ = Task.Run(LoadCityAsync);
        }
    }
}
