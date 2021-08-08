using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class ReceptionMapper
    {
        public static ReceptionMapper Instance { get; private set; } = new ReceptionMapper();
        public WebReception Map(ReceptionBussines cls)
        {
            return new WebReception()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                Description = cls.Description,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                DateM = cls.DateM,
                Number = cls.Number,
                UserGuid = cls.UserGuid,
                TafsilGuid = cls.TafsilGuid,
                SanadNumber = cls.SanadNumber,
                MoeinGuid = cls.MoeinGuid,
                SumHavale = cls.SumHavale,
                SumNaqd = cls.SumNaqd,
                Sum = cls.Sum,
                SumCheck = cls.SumCheck
            };
        }
    }
}
