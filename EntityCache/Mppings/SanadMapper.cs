using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class SanadMapper
    {
        public static SanadMapper Instance { get; private set; } = new SanadMapper();
        public WebSanad Map(SanadBussines cls)
        {
            return new WebSanad()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                UserGuid = cls.UserGuid,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description,
                DateM = cls.DateM,
                Number = cls.Number,
                SanadType = cls.SanadType,
                SanadStatus = cls.SanadStatus,
                DetList = cls.Details
            };
        }
    }
}
