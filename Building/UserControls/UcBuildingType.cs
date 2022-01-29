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
        public bool IsShowWindow { set => cmbWindow.Visible = label2.Visible = value; }
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
        public Guid? BuildingWindowGuid => (Guid?)cmbWindow.SelectedValue;
        public async Task SetBuildingWindowGuidAsync(Guid? value)
        {
            try
            {
                if (WindowBindingSource.Count <= 0)
                    await FillBuildingWindowAsync();
                if (value != null && value != Guid.Empty)
                    cmbWindow.SelectedValue = value;
                else cmbWindow.SelectedIndex = -1;
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
        private async Task FillBuildingWindowAsync()
        {
            try
            {
                var list = await BuildingWindowBussines.GetAllAsync();
                WindowBindingSource.DataSource = list?.Where(q => q.Status)?.ToList()?.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
