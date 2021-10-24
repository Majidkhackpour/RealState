using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class MoeinMapper
    {
        public static MoeinMapper Instance { get; private set; } = new MoeinMapper();
        public WebMoein Map(MoeinBussines cls)
        {
            return new WebMoein()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Code = cls.Code,
                Account = cls.Account,
                DateM = cls.DateM,
                KolGuid = cls.KolGuid
            };
        }
        public List<WebMoein> MapList(List<MoeinBussines> cls)
        {
            var list = new List<WebMoein>();
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
