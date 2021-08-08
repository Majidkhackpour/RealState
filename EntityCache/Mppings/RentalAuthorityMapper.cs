using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class RentalAuthorityMapper
    {
        public static RentalAuthorityMapper Instance { get; private set; } = new RentalAuthorityMapper();
        public WebRental Map(RentalAuthorityBussines cls)
        {
            return new WebRental()
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
