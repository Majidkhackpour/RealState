using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class PardakhtCheckShakhsiBussines : IPardakhtCheckShakhsi
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public DateTime DateSarResid { get; set; } = DateTime.Now;
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public string Description { get; set; }
        public string Number { get; set; }
        public decimal Price { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public Guid CheckPageGuid { get; set; }
        public Guid MasterGuid { get; set; }


        public static async Task<List<PardakhtCheckShakhsiBussines>> GetAllAsync(Guid masterGuid) => await UnitOfWork.PardakhtCheckShakhsi.GetAllAsync(masterGuid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<PardakhtCheckShakhsiBussines> list, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckShakhsi.SaveRangeAsync(list, tranName));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckShakhsi.RemoveRangeAsync(masterGuid));
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
        public static async Task<List<PardakhtCheckViewModel>> GetAllViewModeAsync(string search = "")
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await UnitOfWork.PardakhtCheckShakhsi.GetAllViewModelAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Girande.ToLower().Contains(item.ToLower()) ||
                                                 x.CheckNumber.ToLower().Contains(item.ToLower()) ||
                                                 x.Price.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.StatusName.ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.DateSarResid).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PardakhtCheckViewModel>();
            }
        }
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

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckShakhsi.SaveAsync(this, tranName));
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
        public static async Task<PardakhtCheckShakhsiBussines> GetAsync(Guid guid) => await UnitOfWork.PardakhtCheckShakhsi.GetAsync(guid);
        public static PardakhtCheckShakhsiBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
