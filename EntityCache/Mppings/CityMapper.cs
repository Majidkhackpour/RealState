using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class CityMapper
    {
        public static CityMapper Instance { get; private set; } = new CityMapper();
        public WebCity Map(CitiesBussines cls)
        {
            return new WebCity()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                StateGuid = cls.StateGuid,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
