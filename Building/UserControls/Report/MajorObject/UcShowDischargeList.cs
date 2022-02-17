using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Building.UserControls.Report.MinorObjects;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Report.MajorObject
{
    public partial class UcShowDischargeList : UserControl
    {
        public UcShowDischargeList() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var list = await ContractBussines.DischargeListAsync();
                if (list != null && list.Count > 0)
                {
                    list = list?.OrderBy(q => q.ToDate)?.Take(10)?.ToList();

                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelSarresidEjare.Controls?.Clear();
                        foreach (var item in list)
                        {
                            var c = new ucDischargeList() { Model = item, Width = fPanelSarresidEjare.Width - 30 };
                            fPanelSarresidEjare.Controls.Add(c);
                        }
                    }));
                }
                else
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        fPanelSarresidEjare.Visible = false;
                        lblSarresidNone.Visible = true;
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
