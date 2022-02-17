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
    public partial class UcShowHighPriority : UserControl
    {
        public UcShowHighPriority() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var list = await BuildingReportBussines.GetAllAsync(new BuildingFilter()
                {
                    Priority = EnBuildingPriority.High
                });
                list = list?.Where(q => q.Priority == EnBuildingPriority.SoHigh && !q.IsArchive)?.Take(10)?.ToList();
                if (list != null && list.Count > 0)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelPirority.Controls?.Clear();
                        foreach (var item in list)
                        {
                            var c = new ucBuildingHighPriority() { Building = item, Width = fPanelPirority.Width - 30 };
                            fPanelPirority.Controls.Add(c);
                        }
                    }));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelPirority.Visible = false;
                        lblBuildingNone.Visible = true;
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
