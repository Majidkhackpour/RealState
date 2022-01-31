using Building.UserControls;
using EntityCache.Bussines;
using MetroFramework.Forms;
using Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsSerivces;

namespace Building.Buildings
{
    public partial class frmBuildingLog : MetroForm
    {
        private Guid buildingGuid;
        private async Task LoadDataAsync()
        {
            try
            {
                var list = await UserLogBussines.GetBuildingLogAsync(buildingGuid);
                if (list != null && list.Count > 0)
                {
                    list = list.OrderBy(q => q.Date)?.ToList();
                    BeginInvoke(new MethodInvoker(() => UserLogBindingSource.DataSource = list?.ToSortableBindingList()));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        this.ShowMessage("داده ای جهت نمایش وجود ندارد");
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public frmBuildingLog(Guid buGuid)
        {
            InitializeComponent();
            buildingGuid = buGuid;
        }
        private void frmBuildingLog_Load(object sender, EventArgs e) => _ = Task.Run(LoadDataAsync);
        private void frmBuildingLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
        }
    }
}
