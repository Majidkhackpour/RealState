using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ReceptionCheckAvalDoreBussines : IReceptionCheckAvalDore
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string BankName { get; set; }
        public DateTime DateM { get; set; }
        public DateTime DateSarResid { get; set; }
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public Guid SandouqTafsilGuid { get; set; }
        public string SandouqName { get; set; }
        public Guid SandouqMoeinGuid { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }


        public static async Task<List<ReceptionCheckAvalDoreBussines>> GetAllAsync() =>
            await UnitOfWork.ReceptionCheckAvalDore.GetAllAsync();
        public static async Task<ReceptionCheckAvalDoreBussines> GetAsync(Guid guid) =>
            await UnitOfWork.ReceptionCheckAvalDore.GetAsync(guid);
        public static ReceptionCheckAvalDoreBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(await UnitOfWork.ReceptionCheckAvalDore.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.ReceptionCheckAvalDore.RemoveAsync(Guid, tranName));
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
