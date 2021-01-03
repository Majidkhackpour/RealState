using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class StatesBussines : IStates
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string HardSerial => Cache.HardSerial;

        public static async Task<List<StatesBussines>> GetAllAsync() => await UnitOfWork.States.GetAllAsync();
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<StatesBussines> list,
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

                res.AddReturnedValue(await UnitOfWork.States.SaveRangeAsync(list, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebStates.SaveAsync(list));
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
        public static async Task<StatesBussines> GetAsync(Guid guid) => await UnitOfWork.States.GetAsync(guid);
        public static StatesBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
