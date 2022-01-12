using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services;
using Services.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingNote : IBuildingNote
    {
        private static string Url = Utilities.WebApi + "/api/BuildingNote/SaveAsync";

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }


        private async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SendAsync()
        {
            var ret = new ReturnedSaveFuncInfoWithValue<ResponseStatus>();
            try
            {
                var res = await Extentions.PostToApi<WebBuildingNote, WebBuildingNote>(this, Url, WebCustomer.Customer.Guid);
                ret.value = res?.ResponseStatus ?? ResponseStatus.ErrorInServer;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                ret.AddReturnedValue(ex);
            }

            return ret;
        }
        public static async Task<ReturnedSaveFuncInfoWithValue<ResponseStatus>> SendAsync(WebBuildingNote cls)
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
