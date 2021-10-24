using System;
using System.Collections.Generic;
using EntityCache.Bussines;
using Services;
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
        public List<WebBank> MapList(List<BankBussines> cls)
        {
            var list = new List<WebBank>();
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
