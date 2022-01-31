using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;

namespace Building.Zoncan
{
    public partial class frmSelectZoncan : MetroForm
    {
        public Guid ZoncanGuid { get; private set; }
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await BuildingZoncanBussines.GetAllAsync();
                ZoncanBindingSource.DataSource = list?.Where(q => q.Status)?.OrderBy(q => q.Name);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmSelectZoncan()
        {
            InitializeComponent();
            ucHeader.Text = "انتخاب زونکن";
        }
        private async void frmSelectZoncan_Load(object sender, EventArgs e) => await LoadDataAsync();
        private async Task ucCancel_OnClick(object arg1, EventArgs arg2)
        {
            ZoncanGuid = Guid.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private async Task ucAccept_OnClick(object arg1, EventArgs arg2)
        {
            try
            {
                if (cmbZoncan.SelectedValue == null)
                    ZoncanGuid = Guid.Empty;
                else ZoncanGuid = (Guid) cmbZoncan.SelectedValue;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
