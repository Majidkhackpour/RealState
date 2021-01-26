using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SimcardBussines : ISimcard
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public long Number { get; set; }
        public string Owner { get; set; }
        public string Operator { get; set; }
        public bool isSheypoorBlocked { get; set; }
        public DateTime NextUseSheypoor { get; set; } = DateTime.Now;
        public DateTime NextUseDivar { get; set; } = DateTime.Now;
        public bool HasDivarToken
        {
            get
            {
                var divar = AsyncContext.Run(() => AdvTokenBussines.GetTokenAsync(Number, AdvertiseType.Divar));
                return divar != null && !string.IsNullOrEmpty(divar?.Token);
            }
        }
        public bool HasSheypoorToken
        {
            get
            {
                var sheypoor = AsyncContext.Run(() => AdvTokenBussines.GetTokenAsync(Number, AdvertiseType.Sheypoor));
                return sheypoor != null && !string.IsNullOrEmpty(sheypoor?.Token);
            }
        }


        public static async Task<List<SimcardBussines>> GetAllAsync() => await UnitOfWork.Simcard.GetAllAsync();
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

                res.AddReturnedValue(await UnitOfWork.Simcard.SaveAsync(this, tranName));
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
        public static async Task<SimcardBussines> GetAsync(long number) => await UnitOfWork.Simcard.GetAsync(number);
        public static async Task<List<SimcardBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Owner.ToLower().Contains(item.ToLower())||
                                                 x.Number.ToString().ToLower().Contains(item.ToLower())||
                                                 x.Operator.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Owner).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<SimcardBussines>();
            }
        }
        public static async Task<SimcardBussines> GetAsync(Guid guid) => await UnitOfWork.Simcard.GetAsync(guid);
        public static SimcardBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Simcard.ChangeStatusAsync(this, status, tranName));
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
        public static async Task<bool> CheckNumberAsync(long number, Guid guid) =>
            await UnitOfWork.Simcard.CheckNumberAsync(number, guid);
    }
}
