using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebBuildingReview : IBuildingReview
    {
        private static string Url = Utilities.WebApi + "/api/BuildingReview/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid CustometGuid { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }


        private static void RaiseEvent(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            try
            {
                var handler = OnSaveResult;
                if (handler != null)
                    OnSaveResult?.Invoke(objGuid, st, dateM);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        private async Task SendAsync()
        {
            try
            {
                //var res = await Extentions.PostToApi<WebBuildingWindow, WebBuildingWindow>(this, Url, WebCustomer.Customer.Guid);
                //if (res == null || res.ResponseStatus != ResponseStatus.Success)
                //{

                //    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                //    return;
                //}
                //RaiseEvent(Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SendAsync(WebBuildingReview cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                await cls.SendAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendAsync(List<WebBuildingReview> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                    res.AddReturnedValue(await SendAsync(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
