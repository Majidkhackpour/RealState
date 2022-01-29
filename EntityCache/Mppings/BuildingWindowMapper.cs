using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingWindowMapper
    {
        public static BuildingWindowMapper Instance { get; private set; } = new BuildingWindowMapper();
        public WebBuildingWindow Map(BuildingWindowBussines cls)
        {
            return new WebBuildingWindow()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingWindow> MapList(List<BuildingWindowBussines> cls)
        {
            var list = new List<WebBuildingWindow>();
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
