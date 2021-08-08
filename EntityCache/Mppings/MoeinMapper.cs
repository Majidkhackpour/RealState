using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class MoeinMapper
    {
        public static MoeinMapper Instance { get; private set; } = new MoeinMapper();
        public WebMoein Map(MoeinBussines cls)
        {
            return new WebMoein()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Code = cls.Code,
                Account = cls.Account,
                DateM = cls.DateM,
                KolGuid = cls.KolGuid
            };
        }
    }
}
