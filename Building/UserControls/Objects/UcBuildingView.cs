using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingView : UserControl
    {
        public Guid? BuildingViewGuid => (Guid?)cmbBView.SelectedValue;
        public async Task SetBuildingViewGuidAsync(Guid? value)
        {
            try
            {
                if (BuildingViewBindingSource.Count <= 0)
                    await FillBuildingViewAsync();
                if (value == null) return;
                cmbBView.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcBuildingView() => InitializeComponent();
        private async Task FillBuildingViewAsync()
        {
            try
            {
                var list = await BuildingViewBussines.GetAllAsync();
                BuildingViewBindingSource.DataSource = list?.Where(q => q.Status)?.ToList()?.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
