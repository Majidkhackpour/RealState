using System;
using System.Linq;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Objects
{
    public partial class UcFloorCover : UserControl
    {
        public Guid? FloorCoverGuid
        {
            get => (Guid?)cmbBFloorCover.SelectedValue;
            set
            {
                if (value == null) return;
                cmbBFloorCover.SelectedValue = value;
            }
        }
        public UcFloorCover()
        {
            InitializeComponent();
            FillFloorCover();
        }
        private void FillFloorCover()
        {
            try
            {
                var list = FloorCoverBussines.GetAll("");
                FloorCoverBindingSource.DataSource = list.Where(q => q.Status).ToList().OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
