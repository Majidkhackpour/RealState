using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingZoncanMapper
    {
        public static BuildingZoncanMapper Instance { get; private set; } = new BuildingZoncanMapper();
        public WebBuildingZoncan Map(BuildingZoncanBussines cls)
        {
            return new WebBuildingZoncan()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description
            };
        }
        public List<WebBuildingZoncan> MapList(List<BuildingZoncanBussines> cls)
        {
            var list = new List<WebBuildingZoncan>();
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
