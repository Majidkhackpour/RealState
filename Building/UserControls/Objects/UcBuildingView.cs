using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcBuildingView : UserControl
    {
        public Guid? BuildingViewGuid
        {
            get => (Guid?)cmbBView.SelectedValue;
            set
            {
                if (value == null) return;
                cmbBView.SelectedValue = value;
            }
        }
        public UcBuildingView()
        {
            InitializeComponent();
            FillBuildingView();
        }
        private void FillBuildingView()
        {
            try
            {
                var list = BuildingViewBussines.GetAll();
                BuildingViewBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
