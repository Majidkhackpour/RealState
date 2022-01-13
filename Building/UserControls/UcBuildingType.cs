using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.UserControls
{
    public partial class UcBuildingType : UserControl
    {
        public Guid BuildingTypeGuid
        {
            get
            {
                if (cmbBView.SelectedValue == null) return Guid.Empty;
                return (Guid)cmbBView.SelectedValue;
            }
        }
        public async Task SetBuildingAccountTypeGuidAsync(Guid value)
        {
            try
            {
                if (BuildingAccountTypeBindingSource.Count <= 0)
                    await FillBuildingAccountTypeAsync();
                cmbAccountType.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public Guid BuildingAccountTypeGuid
        {
            get
            {
                if (cmbAccountType.SelectedValue == null) return Guid.Empty;
                return (Guid)cmbAccountType.SelectedValue;
            }
        }
        public async Task SetBuildingTypeGuidAsync(Guid value)
        {
            try
            {
                if (BuildingTypeBindingSource.Count <= 0)
                    await FillBuildingTypeAsync();
                cmbBView.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcBuildingType() => InitializeComponent();
        private async Task FillBuildingTypeAsync()
        {
            try
            {
                var list = await BuildingTypeBussines.GetAllAsync();
                BuildingTypeBindingSource.DataSource = list?.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task FillBuildingAccountTypeAsync()
        {
            try
            {
                var list = await BuildingAccountTypeBussines.GetAllAsync();
                BuildingAccountTypeBindingSource.DataSource = list?.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
