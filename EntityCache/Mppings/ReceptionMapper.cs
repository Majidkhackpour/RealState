using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class ReceptionMapper
    {
        public static ReceptionMapper Instance { get; private set; } = new ReceptionMapper();
        public WebReception Map(ReceptionBussines cls)
        {
            return new WebReception()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                Description = cls.Description,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                DateM = cls.DateM,
                Number = cls.Number,
                UserGuid = cls.UserGuid,
                TafsilGuid = cls.TafsilGuid,
                SanadNumber = cls.SanadNumber,
                MoeinGuid = cls.MoeinGuid,
                SumHavale = cls.SumHavale,
                SumNaqd = cls.SumNaqd,
                Sum = cls.Sum,
                SumCheck = cls.SumCheck
            };
        }
        public List<WebReception> MapList(List<ReceptionBussines> cls)
        {
            var list = new List<WebReception>();
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
