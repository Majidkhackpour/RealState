using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class PeopleMapper
    {
        public static PeopleMapper Instance { get; private set; } = new PeopleMapper();
        public WebPeople Map(PeoplesBussines cls)
        {
            return new WebPeople()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                Account = cls.Account,
                Code = cls.Code,
                AccountFirst = cls.AccountFirst,
                Address = cls.Address,
                FatherName = cls.FatherName,
                DateBirth = cls.DateBirth,
                IdCode = cls.IdCode,
                NationalCode = cls.NationalCode,
                GroupGuid = cls.GroupGuid,
                PlaceBirth = cls.PlaceBirth,
                IssuedFrom = cls.IssuedFrom,
                PostalCode = cls.PostalCode,
                HardSerial = cls.HardSerial,
                TellList = PhoneBookMapper.Instance.MapList(cls.TellList),
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebPeople> MapList(List<PeoplesBussines> cls)
        {
            var list = new List<WebPeople>();
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
