using Advertise.Classes;
using EntityCache.Bussines;
using Notification;
using Services;
using Settings.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHesabBussines;

namespace RealState
{
    public class DivarFiles
    {
        public static void Init() => _ = Task.Run(GetFilesFromDivarAsync);
        private static async Task GetFilesFromDivarAsync()
        {
            try
            {
                //if (!VersionAccess.Advertise) return;
                //if (!clsAdvertise.IsGiveFile) return;
                //if (WebCustomer.Customer == null ||
                //    WebCustomer.Customer.isBlock ||
                //    WebCustomer.Customer.isWebServiceBlock)
                //    return;

                //var getDate = clsAdvertise.GetFileDate;
                //var newDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                //if (getDate != null && getDate > newDate) return;
                //clsAdvertise.GetFileDate = DateTime.Now;

                //var list = await WebScrapper.GetAllAsync(null);
                //if (list == null || list.Count <= 0) return;

                //clsAdvertise.GetFileDate = DateTime.Now;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                clsAdvertise.GetFileDate = DateTime.Now.AddDays(-1);
            }
        }
    }
}
