using EntityCache.Bussines;
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
    }
}
