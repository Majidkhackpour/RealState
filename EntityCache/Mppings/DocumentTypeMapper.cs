using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
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
                ServerStatus = cls.ServerStatus,
                ServerDeliveryDate = cls.ServerDeliveryDate
            };
        }
        public List<WebDocumentType> MapList(List<DocumentTypeBussines> cls)
        {
            var list = new List<WebDocumentType>();
            try
            {
                foreach (var item in cls)
                    list.Add(Map(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
    }
}
