using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class TafsilMapper
    {
        public static TafsilMapper Instance { get; private set; } = new TafsilMapper();
        public WebTafsil Map(TafsilBussines cls)
        {
            return new WebTafsil()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                Name = cls.Name,
                Description = cls.Description,
                Status = cls.Status,
                HesabType = cls.HesabType,
                ServerStatus = cls.ServerStatus,
                DateM = cls.DateM,
                Code = cls.Code,
                AccountFirst = cls.AccountFirst,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Account = cls.Account,
                isSystem = cls.isSystem
            };
        }
        public List<WebTafsil> MapList(List<TafsilBussines> cls)
        {
            var list = new List<WebTafsil>();
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
