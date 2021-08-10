using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class RegionMapper
    {
        public static RegionMapper Instance { get; private set; } = new RegionMapper();
        public WebRegion Map(RegionsBussines cls)
        {
            return new WebRegion()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                CityGuid = cls.CityGuid,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebRegion> MapList(List<RegionsBussines> cls)
        {
            var list = new List<WebRegion>();
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
