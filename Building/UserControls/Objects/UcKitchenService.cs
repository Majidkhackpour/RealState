using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcKitchenService : UserControl
    {
        public Guid? KitchenServiceGuid => (Guid?)cmbKitchenService.SelectedValue;
        public async Task SetKitchenServiceGuidAsync(Guid? value)
        {
            try
            {
                if (KitchenServiceBindingSource.Count <= 0)
                    await FillKitchenServiceAsync();
                if (value == null) return;
                cmbKitchenService.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcKitchenService() => InitializeComponent();
        private async Task FillKitchenServiceAsync()
        {
            try
            {
                var list = await KitchenServiceBussines.GetAllAsync();
                KitchenServiceBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
