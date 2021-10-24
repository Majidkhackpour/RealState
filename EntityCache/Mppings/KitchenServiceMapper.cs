using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class KitchenServiceMapper
    {
        public static KitchenServiceMapper Instance { get; private set; } = new KitchenServiceMapper();
        public WebKitchenService Map(KitchenServiceBussines cls)
        {
            return new WebKitchenService()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebKitchenService> MapList(List<KitchenServiceBussines> cls)
        {
            var list = new List<WebKitchenService>();
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
