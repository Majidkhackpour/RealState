using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingOptionsMapper
    {
        public static BuildingOptionsMapper Instance { get; private set; } = new BuildingOptionsMapper();
        public WebBuildingOptions Map(BuildingOptionsBussines cls)
        {
            return new WebBuildingOptions()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingOptions> MapList(List<BuildingOptionsBussines> cls)
        {
            var list = new List<WebBuildingOptions>();
            try
            {
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
