using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BuildingAccountTypeMapper
    {
        public static BuildingAccountTypeMapper Instance { get; private set; } = new BuildingAccountTypeMapper();
        public WebBuildingAccountType Map(BuildingAccountTypeBussines cls)
        {
            return new WebBuildingAccountType()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebBuildingAccountType> MapList(List<BuildingAccountTypeBussines> cls)
        {
            var list = new List<WebBuildingAccountType>();
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
