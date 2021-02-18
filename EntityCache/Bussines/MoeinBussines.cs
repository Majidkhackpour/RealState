using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class MoeinBussines : IMoein
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid KolGuid { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public decimal Account { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string Diagnosis => Account.AccountDiagnosis();


        public static async Task<List<MoeinBussines>> GetAllAsync() => await UnitOfWork.Moein.GetAllAsync();
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<MoeinBussines> list,
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

                res.AddReturnedValue(await UnitOfWork.Moein.SaveRangeAsync(list, tranName));
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
        public static async Task<MoeinBussines> GetAsync(Guid guid) => await UnitOfWork.Moein.GetAsync(guid);
        public static async Task<List<MoeinBussines>> GetAllAsync(string search, Guid kolGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                res = res.Where(q => q.KolGuid == kolGuid).ToList();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.Account.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<MoeinBussines>();
            }
        }
        public static MoeinBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
