using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BackUpLogBussines : IBackUpLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime InsertedDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(InsertedDate);
        public string Path { get; set; }
        public EnBackUpType Type { get; set; }
        public string TypeName => Type.GetDisplay();
        public EnBackUpStatus BackUpStatus { get; set; }
        public string StatusName => BackUpStatus.GetDisplay();
        public string StatusDesc { get; set; }
        public short Size { get; set; }

        public static async Task<BackUpLogBussines> GetAsync(Guid guid) => await UnitOfWork.BackUpLog.GetAsync(guid);

        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                
                res.AddReturnedValue(await UnitOfWork.BackUpLog.SaveAsync(this, tranName));
                if (res.HasError) return res;
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

        public static async Task<List<BackUpLogBussines>> GetAllAsync() => await UnitOfWork.BackUpLog.GetAllAsync();
    }
}
