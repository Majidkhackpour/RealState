using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class PeoplesBussines : IPeoples
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Code { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string IdCode { get; set; }
        public string FatherName { get; set; }
        public string PlaceBirth { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public string IssuedFrom { get; set; }
        public string PostalCode { get; set; }
        public Guid GroupGuid { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string AccountType => Account.AccountDiagnosis();
        public string FirstNumber =>
            AsyncContext.Run(() => PhoneBookBussines.GetAllAsync(Guid, true))?.FirstOrDefault()?.Tell ?? "";
        public bool IsChecked { get; set; }
        public string HardSerial => Cache.HardSerial;
        public List<PhoneBookBussines> TellList { get; set; }
        public List<PeoplesBankAccountBussines> BankList { get; set; }

        public static async Task<List<PeoplesBussines>> GetAllAsync() => await UnitOfWork.Peoples.GetAllAsync();
        public static async Task<PeoplesBussines> GetAsync(Guid guid) => await UnitOfWork.Peoples.GetAsync(guid);
        public static async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.Peoples.GetAllAsync(parentGuid, status);
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

                if (TellList.Count > 0)
                {
                    var list = await PhoneBookBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.PhoneBook.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    if (res.HasError) return res;

                    foreach (var item in TellList)
                    {
                        item.ParentGuid = Guid;
                        item.Name = Name;
                    }
                    res.AddReturnedValue(
                        await UnitOfWork.PhoneBook.SaveRangeAsync(TellList, tranName));
                    if (res.HasError) return res;
                }
                if (BankList.Count > 0)
                {
                    var list = await PeoplesBankAccountBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.PeopleBankAccount.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    if (res.HasError) return res;

                    foreach (var item in BankList)
                        item.ParentGuid = Guid;
                    res.AddReturnedValue(
                        await UnitOfWork.PeopleBankAccount.SaveRangeAsync(BankList, tranName));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebPeople.SaveAsync(this));
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
                    res.AddError("شخص انتخاب شده معتبر نمی باشد");
                    return res;
                }

                res.AddReturnedValue(await tafsil.ChangeStatusAsync(status));
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Peoples.ChangeStatusAsync(this, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeople.SaveAsync(this));
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
        public static PeoplesBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<List<PeoplesBussines>> GetAllAsync(string search, Guid groupGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                IEnumerable<PeoplesBussines> res;
                if (groupGuid == Guid.Empty)
                    res = await GetAllAsync();
                else res = await GetAllAsync(groupGuid, true);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToLower().Contains(item.ToLower()));
                        }
                    }

                res = res.OrderBy(q => q.Code);
                return res?.ToList();
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PeoplesBussines>();
            }
        }
        public static async Task<List<PeoplesBussines>> GetAllBirthDayAsync(string dateSh) =>
            await UnitOfWork.Peoples.GetAllBirthDayAsync(dateSh);
        public async Task<bool> CheckCodeAsync(Guid guid, string code) => await UnitOfWork.Tafsil.CheckCodeAsync(guid, code);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان شخص نمی تواند خالی باشد");
                if (string.IsNullOrEmpty(Code)) res.AddError("کد شخص نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Guid, Code)) res.AddError("کد شخص معتبر نمی باشد");
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
                    DateM = DateTime.Now,
                    Account = 0,
                    HesabType = HesabType.Customer,
                    Modified = Modified,
                    Status = true,
                    isSystem = false
                };

                tf.Code = Code;
                tf.Name = Name;
                tf.Description = "";
                tf.AccountFirst = AccountFirst;

                res.AddReturnedValue(await tf.SaveAsync());
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
