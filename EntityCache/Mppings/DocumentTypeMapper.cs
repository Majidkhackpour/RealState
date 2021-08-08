using EntityCache.Bussines;
using WebHesabBussines;

namespace EntityCache.Mppings
{
    public class DocumentTypeMapper
    {
        public static DocumentTypeMapper Instance { get; private set; } = new DocumentTypeMapper();
        public WebDocumentType Map(DocumentTypeBussines cls)
        {
            return new WebDocumentType()
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
