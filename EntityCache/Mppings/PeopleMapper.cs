using EntityCache.Bussines;
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
                TellList = cls.TellList,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
