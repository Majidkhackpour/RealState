using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class RentalAuthorityMapper
    {
        public static RentalAuthorityMapper Instance { get; private set; } = new RentalAuthorityMapper();
        public WebRental Map(RentalAuthorityBussines cls)
        {
            return new WebRental()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebRental> MapList(List<RentalAuthorityBussines> cls)
        {
            var list = new List<WebRental>();
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
