using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Building
{
    public partial class frmShowBuildingDetail : MetroForm
    {
        private BuildingBussines bu;

        private async Task SetDataAsync()
        {
            try
            {
                if (bu == null)
                {
                    this.ShowWarning("ملک موردنظر معتبر نمی باشد");
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public frmShowBuildingDetail(BuildingBussines _bu)
        {
            InitializeComponent();
            _bu = bu;
        }

        private async void frmShowBuildingDetail_Load(object sender, System.EventArgs e) => await SetDataAsync();
    }
}
