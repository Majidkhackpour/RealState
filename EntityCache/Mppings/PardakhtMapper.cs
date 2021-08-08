using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class PardakhtMapper
    {
        public static PardakhtMapper Instance { get; private set; } = new PardakhtMapper();
        public WebPardakht Map(PardakhtBussines cls)
        {
            return new WebPardakht()
            {
                Guid = cls.Guid,
                Modified = cls.Modified,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description,
                DateM = cls.DateM,
                Number = cls.Number,
                UserGuid = cls.UserGuid,
                SanadNumber = cls.SanadNumber,
                TafsilGuid = cls.TafsilGuid,
                MoeinGuid = cls.MoeinGuid,
                SumHavale = cls.SumHavale,
                SumNaqd = cls.SumNaqd,
                SumCheckMoshtari = cls.SumCheckMoshtari,
                Sum = cls.Sum,
                SumCheckShakhsi = cls.SumCheckShakhsi
            };
        }
    }
}
