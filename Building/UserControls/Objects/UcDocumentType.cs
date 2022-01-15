using EntityCache.Bussines;
using Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.UserControls.Objects
{
    public partial class UcDocumentType : UserControl
    {
        public Guid? SanadTypeGuid => (Guid?) cmbSellSanadType.SelectedValue;
        public async Task SetSanadTypeGuidAsync(Guid? value)
        {
            try
            {
                if (sanadTypeBindingSource.Count <= 0)
                    await FillSanadTypeAsync();
                if (value == null) return;
                cmbSellSanadType.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcDocumentType()=>InitializeComponent();
        private async Task FillSanadTypeAsync()
        {
            try
            {
                var list = await DocumentTypeBussines.GetAllAsync();
                sanadTypeBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
