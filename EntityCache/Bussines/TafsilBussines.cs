using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.DefaultCoding;

namespace EntityCache.Bussines
{
    public class TafsilBussines : ITafsil
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public bool isSystem { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string Diagnosis => Account.AccountDiagnosis();


        public static async Task<List<TafsilBussines>> GetAllAsync() => await UnitOfWork.Tafsil.GetAllAsync();
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<TafsilBussines> list, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UnitOfWork.Tafsil.SaveRangeAsync(list, tranName));
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

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Tafsil.SaveAsync(this, tranName));
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
        public static async Task<TafsilBussines> GetAsync(Guid guid) => await UnitOfWork.Tafsil.GetAsync(guid);
        public static async Task<List<TafsilBussines>> GetAllAsync(string search, HesabType htype = HesabType.All)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync();
                if (htype != HesabType.All) res = res.Where(q => q.HesabType == htype).ToList();
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
                return new List<TafsilBussines>();
            }
        }
        public static TafsilBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<string> NextCodeAsync(HesabType hType) => await UnitOfWork.Tafsil.NextCodeAsync(hType);
        public static string NextCode(HesabType hType) => AsyncContext.Run(() => NextCodeAsync(hType));
        public async Task<bool> CheckCodeAsync(Guid guid, string code) => await UnitOfWork.Tafsil.CheckCodeAsync(guid, code);
        public static async Task<bool> CheckNameAsync(string name) => await UnitOfWork.Tafsil.CheckNameAsync(name);
        public async Task<ReturnedSaveFuncInfo> UpdateAccountAsync(decimal price) =>
            await UnitOfWork.Tafsil.UpdateAccountAsync(Guid, price);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان حساب نمی تواند خالی باشد");
                if (string.IsNullOrEmpty(Code)) res.AddError("کد حساب نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Guid, Code)) res.AddError("کد حساب معتبر نمی باشد");
                if (HesabType == HesabType.Bank || HesabType == HesabType.Sandouq)
                    if (Account < 0)
                        res.AddError("ماهیت حساب بانک و صندوق بدهکار است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
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

                res.AddReturnedValue(await UnitOfWork.Tafsil.ChangeStatusAsync(this, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebHazine.SaveAsync(this));
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
