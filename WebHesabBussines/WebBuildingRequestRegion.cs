using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebHesabBussines
{
    public class WebBuildingRequestRegion : IBuildingRequestRegion
    {
        private static string Url = Utilities.WebApi + "/api/BuildingRequestRegion/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }


        private async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SaveAsync()
        {
            var res = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var ret = await Extentions.PostToApi<WebBuildingRequestRegion, WebBuildingRequestRegion>(this, Url, WebCustomer.Customer.Guid);
                res.value = ret?.ResponseStatus??ResponseStatus.ErrorInServer;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SaveAsync(WebBuildingRequestRegion cls)
        {
            var res = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var ret = await cls.SaveAsync();
                res.AddReturnedValue(ret);
                res.value = ret.value;
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
