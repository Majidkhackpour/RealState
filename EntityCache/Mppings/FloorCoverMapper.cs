using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class FloorCoverMapper
    {
        public static FloorCoverMapper Instance { get; private set; } = new FloorCoverMapper();
        public WebFloorCover Map(FloorCoverBussines cls)
        {
            return new WebFloorCover()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
    }
}
