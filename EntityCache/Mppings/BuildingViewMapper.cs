using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingViewMapper
    {
        public static BuildingViewMapper Instance { get; private set; } = new BuildingViewMapper();
        public WebBuildingView Map(BuildingViewBussines cls)
        {
            return new WebBuildingView()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingView> MapList(List<BuildingViewBussines> cls)
        {
            var list=new List<WebBuildingView>();
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
