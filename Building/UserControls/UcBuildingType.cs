using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
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
            set => cmbBView.SelectedValue = value;
        }
        public Guid BuildingAccountTypeGuid
        {
            get
            {
                if (cmbAccountType.SelectedValue == null) return Guid.Empty;
                return (Guid)cmbAccountType.SelectedValue;
            }
            set => cmbAccountType.SelectedValue = value;
        }
        public UcBuildingType()
        {
            InitializeComponent();
            FillBuildingAccountType();
            FillBuildingType();
        }
        private void FillBuildingType()
        {
            try
            {
                var list = BuildingTypeBussines.GetAll();
                BuildingTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private void FillBuildingAccountType()
        {
            try
            {
                var list = BuildingAccountTypeBussines.GetAll("");
                BuildingAccountTypeBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
