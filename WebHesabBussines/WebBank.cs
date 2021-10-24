using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Services.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBank : IBank
    {
        private static string Url = Utilities.WebApi + "/api/Bank/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;


        public Guid Guid { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shobe { get; set; }
        public string CodeShobe { get; set; }
        public string HesabNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateM { get; set; }


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
        private async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebBank, WebBank>(this, Url, WebCustomer.Customer.Guid);
                if (res.ResponseStatus != ResponseStatus.Success)
                {
                    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                    return;
                }
                RaiseEvent(Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBank cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                await cls.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebBank> cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in cls)
                    res.AddReturnedValue(await SaveAsync(item));
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
