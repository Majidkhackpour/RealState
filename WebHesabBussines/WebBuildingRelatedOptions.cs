using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingRelatedOptions : IBuildingRelatedOptions
    {
        private static string Url = Utilities.WebApi + "/api/BuildingRelatedOptions/SaveAsync";


        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
        public DateTime Modified { get; set; }
        public string HardSerial { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }



        public async Task SaveAsync()
        {
            try
            {
                await Extentions.PostToApi<BuildingRelatedOptionsBussines, WebBuildingRelatedOptions>(this, Url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingRelatedOptionsBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                {
                    var obj = new WebBuildingRelatedOptions()
                    {
                        Guid = cls.Guid,
                        HardSerial = cls.HardSerial,
                        BuildingOptionGuid = cls.BuildingOptionGuid,
                        BuildinGuid = cls.BuildinGuid,
                        Modified = cls.Modified
                    };
                    await obj.SaveAsync();
                }
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
