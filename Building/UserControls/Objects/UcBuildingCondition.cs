using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingCondition : UserControl
    {
        public Guid? BuildingConditionGuid
        {
            get => (Guid?)cmbBuildingCondition.SelectedValue;
            set
            {
                if (value == null) return;
                cmbBuildingCondition.SelectedValue = value;
            }
        }
        public UcBuildingCondition()
        {
            InitializeComponent();
            FillBuildingCondition();
        }
        private void FillBuildingCondition()
        {
            try
            {
                var list = BuildingConditionBussines.GetAll("");
                bConditionBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
