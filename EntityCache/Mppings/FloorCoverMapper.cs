using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class FloorCoverMapper
    {
        public static FloorCoverMapper Instance { get; private set; } = new FloorCoverMapper();
        public WebFloorCover Map(FloorCoverBussines cls)
        {
            return new WebFloorCover()
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
        public List<WebFloorCover> MapList(List<FloorCoverBussines> cls)
        {
            var list = new List<WebFloorCover>();
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
