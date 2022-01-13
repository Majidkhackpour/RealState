using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingCondition : UserControl
    {
        public Guid? BuildingConditionGuid => (Guid?)cmbBuildingCondition.SelectedValue;
        public async Task SetBuildingConditionGuidAsync(Guid? value)
        {
            try
            {
                if (bConditionBindingSource.Count <= 0)
                    await FillBuildingConditionAsync();
                if (value == null) return;
                cmbBuildingCondition.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcBuildingCondition() => InitializeComponent();
        private async Task FillBuildingConditionAsync()
        {
            try
            {
                var list = await BuildingConditionBussines.GetAllAsync();
                bConditionBindingSource.DataSource = list?.Where(q => q.Status)?.ToList()?.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
