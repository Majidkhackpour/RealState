using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingConditionMapper
    {
        public static BuildingConditionMapper Instance { get; private set; } = new BuildingConditionMapper();
        public WebBuildingCondition Map(BuildingConditionBussines cls)
        {
            return new WebBuildingCondition()
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
        public List<WebBuildingCondition> MapList(List<BuildingConditionBussines> cls)
        {
            var list = new List<WebBuildingCondition>();
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
