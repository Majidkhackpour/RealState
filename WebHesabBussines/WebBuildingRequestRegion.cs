using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;
using Servicess.Interfaces.Building;

namespace WebHesabBussines
{
    public class WebBuildingRequestRegion : IBuildingRequestRegion
    {
        private static string Url = Utilities.WebApi + "/api/BuildingRequestRegion/SaveAsync";


        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid RequestGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string HardSerial { get; set; }


        public async Task SaveAsync()
        {
            try
            {
                await Extentions.PostToApi<BuildingRequestRegionBussines, WebBuildingRequestRegion>(this, Url);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SaveAsync(List<BuildingRequestRegionBussines> item)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var cls in item)
                {
                    var obj = new WebBuildingRequestRegion()
                    {
                        Guid = cls.Guid,
                        Modified = cls.Modified,
                        HardSerial = cls.HardSerial,
                        RegionGuid = cls.RegionGuid,
                        RequestGuid = cls.RequestGuid
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
