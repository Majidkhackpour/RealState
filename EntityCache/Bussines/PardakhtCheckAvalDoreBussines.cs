using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class PardakhtCheckAvalDoreBussines : IPardakhtCheckAvalDore
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string DasteCheckName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateSarresid { get; set; }
        public string Number { get; set; }
        public Guid CheckPageGuid { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }


        public static async Task<List<PardakhtCheckAvalDoreBussines>> GetAllAsync() =>
            await UnitOfWork.PardakhtCheckAvalDore.GetAllAsync();
        public static async Task<PardakhtCheckAvalDoreBussines> GetAsync(Guid guid) =>
            await UnitOfWork.PardakhtCheckAvalDore.GetAsync(guid);
        public static PardakhtCheckAvalDoreBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckAvalDore.SaveAsync(this, tranName));
                if (res.HasError) return res;

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                {
                    //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckAvalDore.RemoveAsync(Guid, tranName));
                if (res.HasError) return res;

                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
