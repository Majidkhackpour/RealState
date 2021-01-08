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
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildinGuid { get; set; }
        public Guid BuildingOptionGuid { get; set; }
        public string HardSerial { get; set; }



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
                        Modified = cls.Modified,
                        Status = cls.Status,
                        HardSerial = cls.HardSerial,
                        BuildingOptionGuid = cls.BuildingOptionGuid,
                        BuildinGuid = cls.BuildinGuid
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
