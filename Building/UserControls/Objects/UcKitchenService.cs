using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcKitchenService : UserControl
    {
        public Guid? KitchenServiceGuid
        {
            get => (Guid?)cmbKitchenService.SelectedValue;
            set
            {
                if (value == null) return;
                cmbKitchenService.SelectedValue = value;
            }
        }
        public UcKitchenService()
        {
            InitializeComponent();
            FillKitchenService();
        }
        private void FillKitchenService()
        {
            try
            {
                var list = KitchenServiceBussines.GetAll("");
                KitchenServiceBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
