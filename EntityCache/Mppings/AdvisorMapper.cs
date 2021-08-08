using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class AdvisorMapper
    {
        public static AdvisorMapper Instance { get; private set; } = new AdvisorMapper();
        public WebAdvisor Map(AdvisorBussines cls)
        {
            return new WebAdvisor()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Address = cls.Address
            };
        }
    }
}
