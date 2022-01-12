using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebBuildingRequest : IBuildingRequest
    {
        private static string Url = Utilities.WebApi + "/api/BuildingRequest/SaveAsync";
        public static event Func<Guid, ServerStatus, DateTime, Task> OnSaveResult;


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid AskerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellPrice2 { get; set; }
        public bool? HasVam { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public short? PeopleCount { get; set; }
        public bool? HasOwner { get; set; }
        public bool? ShortDate { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public Guid CityGuid { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public int Masahat1 { get; set; }
        public int Masahat2 { get; set; }
        public int RoomCount { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public string ShortDesc { get; set; }
        public List<WebBuildingRequestRegion> RegionList { get; set; }


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
                var res = await Extentions.PostToApi<WebBuildingRequest, WebBuildingRequest>(this, Url, WebCustomer.Customer.Guid);
                if (res == null || res.ResponseStatus != ResponseStatus.Success)
                {
                    RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                    return;
                }

                if (RegionList != null && RegionList.Count > 0)
                {
                    foreach (var item in RegionList)
                    {
                        var ret = await WebBuildingRequestRegion.SaveAsync(item);
                        if (ret.HasError || ret.value == null || ret.value != ResponseStatus.Success)
                        {
                            RaiseEvent(Guid, ServerStatus.DeliveryError, DateTime.Now);
                            return;
                        }
                    }
                }

                RaiseEvent(Guid, ServerStatus.Delivered, DateTime.Now);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SendAsync(WebBuildingRequest cls)
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
        public static async Task<ReturnedSaveFuncInfo> SendAsync(List<WebBuildingRequest> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                    res.AddReturnedValue(await SendAsync(cls));
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
