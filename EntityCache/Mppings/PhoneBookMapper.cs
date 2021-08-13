using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class PhoneBookMapper
    {
        public static PhoneBookMapper Instance { get; private set; } = new PhoneBookMapper();
        public WebPhoneBook Map(PhoneBookBussines cls)
        {
            return new WebPhoneBook()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ParentGuid = cls.ParentGuid,
                Tell = cls.Tell,
                Group = cls.Group,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Title = cls.Title
            };
        }
        public List<WebPhoneBook> MapList(List<PhoneBookBussines> cls)
        {
            var list = new List<WebPhoneBook>();
            try
            {
                if (cls == null || cls.Count <= 0) return list;
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
