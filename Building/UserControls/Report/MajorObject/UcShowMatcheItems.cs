using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.UserControls.Report.MinorObjects;
using EntityCache.ViewModels;
using Services;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowMatcheItems : UserControl
    {
        public UcShowMatcheItems() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var list = await BuildingRequestViewModel.GetAllMatchesItemsAsync(new CancellationToken());
                if (list != null && list.Count > 0)
                {
                    list = list.OrderByDescending(q => q.RequestCount)?.Take(10)?.ToList();

                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelMath.Controls?.Clear();
                        fPanelMath.Visible = true;
                        lblMatchNone.Visible = false;
                        foreach (var item in list)
                        {
                            var c = new ucBuildingMatch() { Model = item, Width = fPanelMath.Width - 30 };
                            fPanelMath.Controls.Add(c);
                        }
                    }));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelMath.Visible = false;
                        lblMatchNone.Visible = true;
                    }));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
