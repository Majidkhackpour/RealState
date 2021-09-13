using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebBuildingRelatedOptions : IBuildingRelatedOptions
    {
        private static string Url = Utilities.WebApi + "/api/BuildingRelatedOptions/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;

        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }



        private static void RaiseEvent(Guid objGuid, ServerStatus st, DateTime dateM)
        {
            var handler = OnSaveResult;
            if (handler != null)
                OnSaveResult(objGuid, st, dateM);
        }
        public async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebBuildingRelatedOptions, WebBuildingRelatedOptions>(this, Url);
                if (res!=null&& res.ResponseStatus != ResponseStatus.Success)
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuildingRelatedOptions cls)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var obj = new WebBuildingRelatedOptions()
                {
                    Guid = cls.Guid,
                    HardSerial = cls.HardSerial,
                    BuildingOptionGuid = cls.BuildingOptionGuid,
                    BuildinGuid = cls.BuildinGuid,
                    Modified = cls.Modified,
                    ServerStatus = cls.ServerStatus,
                    ServerDeliveryDate = cls.ServerDeliveryDate
                };
                await obj.SaveAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebBuildingRelatedOptions> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (item == null) return res;
                foreach (var cls in item)
                    res.AddReturnedValue(await SaveAsync(cls));
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
