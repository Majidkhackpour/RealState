﻿using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class SanadDetailMapper
    {
        public static SanadDetailMapper Instance { get; private set; } = new SanadDetailMapper();
        public WebSanadDetail Map(SanadDetailBussines cls)
        {
            return new WebSanadDetail()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description,
                Debit = cls.Debit,
                Credit = cls.Credit,
                TafsilGuid = cls.TafsilGuid,
                MoeinGuid = cls.MoeinGuid,
                MasterGuid = cls.MasterGuid
            };
        }
        public List<WebSanadDetail> MapList(List<SanadDetailBussines> cls)
        {
            var list = new List<WebSanadDetail>();
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