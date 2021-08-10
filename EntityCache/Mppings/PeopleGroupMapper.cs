using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class PeopleGroupMapper
    {
        public static PeopleGroupMapper Instance { get; private set; } = new PeopleGroupMapper();
        public WebPeopleGroup Map(PeopleGroupBussines cls)
        {
            return new WebPeopleGroup()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                ParentGuid = cls.ParentGuid,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebPeopleGroup> MapList(List<PeopleGroupBussines> cls)
        {
            var list = new List<WebPeopleGroup>();
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
