using EntityCache.Bussines;
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
    }
}
