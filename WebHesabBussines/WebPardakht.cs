using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebPardakht : IPardakht
    {
        private static string Url = Utilities.WebApi + "/api/BuildingPardakht/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public Guid TafsilGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public Guid UserGuid { get; set; }
        public long Number { get; set; }
        public long SanadNumber { get; set; }
        public decimal SumCheckMoshtari { get; set; }
        public decimal SumCheckShakhsi { get; set; }
        public decimal SumHavale { get; set; }
        public decimal SumNaqd { get; set; }
        public decimal Sum { get; set; }


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
                var res = await Extentions.PostToApi<WebPardakht, WebPardakht>(this, Url, WebCustomer.Customer.Guid);
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebPardakht cls)
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebPardakht> cls)
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
