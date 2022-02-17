using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityCache.Bussines;
using Services;

namespace Building.UserControls.Report
{
    public partial class UcReport : UserControl
    {
        public UcReport() => InitializeComponent();
        public async Task InitAsync()
        {
            try
            {
                var list = new List<Task>
                {
                    Task.Run(ucShowCustomerBirthday1.InitAsync),
                    Task.Run(ucShowDischargeList1.InitAsync),
                    Task.Run(ucShowHighPriority1.InitAsync),
                    Task.Run(ucShowMatcheItems1.InitAsync),
                };
                await Task.WhenAll(list);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
