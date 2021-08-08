using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class KitchenServiceMapper
    {
        public static KitchenServiceMapper Instance { get; private set; } = new KitchenServiceMapper();
        public WebKitchenService Map(KitchenServiceBussines cls)
        {
            return new WebKitchenService()
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
