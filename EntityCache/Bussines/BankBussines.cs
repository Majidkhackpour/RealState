using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nito.AsyncEx;

namespace EntityCache.Bussines
{
    public class BankBussines : IBank
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Code { get; set; }
        public string Name { get; set; }
        public string Shobe { get; set; }
        public string CodeShobe { get; set; }
        public string HesabNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public decimal Account { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string Diagnosis => Account.AccountDiagnosis();


        public static async Task<List<BankBussines>> GetAllAsync() => await UnitOfWork.Bank.GetAllAsync();
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
                res.AddReturnedValue(await SaveTafsilAsync());
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Bank.SaveAsync(this, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebUser.SaveAsync(this));
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
        public static async Task<List<BankBussines>> GetAllAsync(string search)
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
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.Account.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.Shobe.ToLower().Contains(item.ToLower()) ||
                                                 x.CodeShobe.ToLower().Contains(item.ToLower()) ||
                                                 x.HesabNumber.ToLower().Contains(item.ToLower()))
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
                return new List<BankBussines>();
            }
        }
        public static async Task<BankBussines> GetAsync(Guid guid) => await UnitOfWork.Bank.GetAsync(guid);
        public static BankBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<bool> CheckCodeAsync(Guid guid, string code) => await UnitOfWork.Tafsil.CheckCodeAsync(guid, code);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان حساب نمی تواند خالی باشد");
                if (string.IsNullOrEmpty(Code)) res.AddError("کد حساب نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Guid, Code)) res.AddError("کد حساب معتبر نمی باشد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveTafsilAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tf = await TafsilBussines.GetAsync(Guid) ?? new TafsilBussines
                {
                    Guid = Guid,
                    DateM = DateM,
                    Account = 0,
                    HesabType = HesabType.Bank,
                    Modified = Modified,
                    Status = true,
                    isSystem = false
                };

                tf.Code = Code;
                tf.Name = Name;
                tf.Description = Description;

                res.AddReturnedValue(await tf.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
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

                var tafsil = await TafsilBussines.GetAsync(Guid);
                if (tafsil == null)
                {
                    res.AddError("حساب انتخاب شده معتبر نمی باشد");
                    return res;
                }

                res.AddReturnedValue(await tafsil.ChangeStatusAsync(status));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Bank.ChangeStatusAsync(this, status, tranName));
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
