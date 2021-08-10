using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class KolMapper
    {
        public static KolMapper Instance { get; private set; } = new KolMapper();
        public WebKol Map(KolBussines cls)
        {
            return new WebKol()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Code = cls.Code,
                Account = cls.Account,
                HesabGroup = cls.HesabGroup
            };
        }
        public List<WebKol> MapList(List<KolBussines> cls)
        {
            var list = new List<WebKol>();
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
