using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class NaqzBussines : INaqz
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Message { get; set; }
        public int UseCount { get; set; }


        public static async Task<List<NaqzBussines>> GetAllAsync() => await UnitOfWork.Naqz.GetAllAsync();
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<NaqzBussines> list,
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

                res.AddReturnedValue(await UnitOfWork.Naqz.SaveRangeAsync(list, tranName));
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
        public static async Task<string> SetNaqzAsync(string tranName = "")
        {
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                var all = await GetAllAsync();
                all = all.OrderBy(q => q.UseCount).ToList();
                var one = all.First();

                if (one.UseCount >= 32000) one.UseCount = 1;
                else one.UseCount += 1;

                var res = new ReturnedSaveFuncInfo();
                res.AddReturnedValue(await UnitOfWork.Naqz.SaveAsync(one, tranName));
                res.ThrowExceptionIfError();

                return one.Message;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
