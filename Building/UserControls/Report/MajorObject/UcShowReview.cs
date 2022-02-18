using Building.UserControls.Report.MinorObjects;
using EntityCache.Bussines.ReportBussines;
using Services;
using Services.FilterObjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowReview : UserControl
    {
        public UcShowReview() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var filter = new BuildingReviewFilter()
                {
                    Date1 = Calendar.StartDayOfPersianMonth(),
                    Date2 = Calendar.EndDayOfPersianMonth()
                };
                var list = await BuildingReviewReportBussines.GetAllAsync(filter);
                if (list != null && list.Count > 0)
                {
                    list = list.OrderByDescending(q => q.Date)?.Take(10)?.ToList();

                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelMath.Visible = true;
                        lblMatchNone.Visible = false;
                        fPanelMath.Controls?.Clear();
                        foreach (var item in list)
                        {
                            var c = new ucRegionReport() { Report = item, Width = fPanelMath.Width - 30 };
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
