using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcFloorCover : UserControl
    {
        public Guid? FloorCoverGuid => (Guid?)cmbBFloorCover.SelectedValue;
        public async Task SetFloorCoverGuidAsync(Guid? value)
        {
            try
            {
                if (FloorCoverBindingSource.Count <= 0)
                    await FillFloorCoverAsync();
                if (value == null) return;
                cmbBFloorCover.SelectedValue = value;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public UcFloorCover() => InitializeComponent();
        private async Task FillFloorCoverAsync()
        {
            try
            {
                var list = await FloorCoverBussines.GetAllAsync();
                FloorCoverBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name)?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
