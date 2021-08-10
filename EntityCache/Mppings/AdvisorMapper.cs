using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class AdvisorMapper
    {
        public static AdvisorMapper Instance { get; private set; } = new AdvisorMapper();
        public WebAdvisor Map(AdvisorBussines cls)
        {
            return new WebAdvisor()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Address = cls.Address
            };
        }
        public List<WebAdvisor> MapList(List<AdvisorBussines> cls)
        {
            var list = new List<WebAdvisor>();
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
