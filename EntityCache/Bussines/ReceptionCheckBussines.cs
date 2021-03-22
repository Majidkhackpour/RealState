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
    public class ReceptionCheckBussines : IReceptionCheck
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string BankName { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public DateTime DateSarResid { get; set; }
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public Guid MasterGuid { get; set; }
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public string StatusName => CheckStatus.GetDisplay();
        public Guid SandouqTafsilGuid { get; set; }
        public Guid SandouqMoeinGuid { get; set; }


        public static async Task<List<ReceptionCheckBussines>> GetAllAsync(Guid masterGuid) => await UnitOfWork.ReceptionCheck.GetAllAsync(masterGuid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<ReceptionCheckBussines> list, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.ReceptionCheck.SaveRangeAsync(list, tranName));
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

                res.AddReturnedValue(await UnitOfWork.ReceptionCheck.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.ReceptionCheck.RemoveRangeAsync(masterGuid));
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
        public static async Task<List<ReceptionCheckViewModel>> GetAllViewModeAsync(string search = "")
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await UnitOfWork.ReceptionCheck.GetAllViewModelAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Pardazande.ToLower().Contains(item.ToLower()) ||
                                                 x.CheckNumber.ToLower().Contains(item.ToLower()) ||
                                                 x.Price.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SandouqTafsilName.ToLower().Contains(item.ToLower()) ||
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
                return new List<ReceptionCheckViewModel>();
            }
        }
        public static async Task<ReceptionCheckBussines> GetAsync(Guid guid) => await UnitOfWork.ReceptionCheck.GetAsync(guid);
        public static ReceptionCheckBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
