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


        private async Task SaveAsync()
        {
            try
            {
                var res = await Extentions.PostToApi<WebBuildingNote, WebBuildingNote>(this, Url, WebCustomer.Customer.Guid);
                if (res.ResponseStatus != ResponseStatus.Success)
                    return;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(WebBuildingNote cls)
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
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<WebBuildingNote> cls)
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
