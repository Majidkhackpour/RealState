using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class RegionMapper
    {
        public static RegionMapper Instance { get; private set; } = new RegionMapper();
        public WebRegion Map(RegionsBussines cls)
        {
            return new WebRegion()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                CityGuid = cls.CityGuid,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
