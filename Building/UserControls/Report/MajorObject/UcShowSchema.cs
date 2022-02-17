using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowSchema : UserControl
    {
        public UcShowSchema()=>InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var allBuilding = await BuildingBussines.DbCount(Guid.Empty, 0);
                var myBuilding = await BuildingBussines.DbCount(UserBussines.CurrentUser.Guid, 0);
                var rahn = await BuildingBussines.DbCount(Guid.Empty, 1);
                var foroush = await BuildingBussines.DbCount(Guid.Empty, 2);
                var allReq = await BuildingRequestBussines.DbCount(Guid.Empty);
                var myReq = await BuildingRequestBussines.DbCount(UserBussines.CurrentUser.Guid);
                BeginInvoke(new MethodInvoker(() =>
                {
                    lblAllBuilding.Text = allBuilding.ToString();
                    lblMyBuilding.Text = myBuilding.ToString();
                    lblAllRahn.Text = rahn.ToString();
                    lblAllForoosh.Text = foroush.ToString();
                    lblAllRequest.Text = allReq.ToString();
                    lblMyRequest.Text = myReq.ToString();
                }));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
