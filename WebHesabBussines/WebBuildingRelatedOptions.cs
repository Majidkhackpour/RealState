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

        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
        public DateTime Modified { get; set; }



        private async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SendAsync()
        {
            var ret = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var res = await Extentions.PostToApi<WebBuildingRelatedOptions, WebBuildingRelatedOptions>(this, Url, WebCustomer.Customer.Guid);
                ret.value = res?.ResponseStatus??ResponseStatus.ErrorInServer;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }

            return ret;
        }
        public static async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SendAsync(WebBuildingRelatedOptions cls)
        {
            var res = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var ret = await cls.SendAsync();
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
