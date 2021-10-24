using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class SanadMapper
    {
        public static SanadMapper Instance { get; private set; } = new SanadMapper();
        public WebSanad Map(SanadBussines cls)
        {
            return new WebSanad()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                UserGuid = cls.UserGuid,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description,
                DateM = cls.DateM,
                Number = cls.Number,
                SanadType = cls.SanadType,
                SanadStatus = cls.SanadStatus,
                DetList = SanadDetailMapper.Instance.MapList(cls.Details)
            };
        }
        public List<WebSanad> MapList(List<SanadBussines> cls)
        {
            var list = new List<WebSanad>();
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
