using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class BankMapper
    {
        public static BankMapper Instance { get; private set; } = new BankMapper();
        public WebBank Map(BankBussines cls)
        {
            return new WebBank()
            {
                Guid = cls.Guid,
                Name = cls.Name,
                Modified = cls.Modified,
                Status = cls.Status,
                HardSerial = cls.HardSerial,
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate,
                Description = cls.Description,
                Code = cls.Code,
                DateM = cls.DateM,
                Shobe = cls.Shobe,
                CodeShobe = cls.CodeShobe,
                HesabNumber = cls.HesabNumber
            };
        }
    }
}
