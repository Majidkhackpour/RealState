using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using PacketParser.Interfaces;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class DocumentTypeBussines : IDocumentType
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }


        public static async Task<List<DocumentTypeBussines>> GetAllAsync() => await UnitOfWork.DocumentType.GetAllAsync();

        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<DocumentTypeBussines> list,
            string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.DocumentType.SaveRangeAsync(list, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
