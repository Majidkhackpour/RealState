using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
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
        public string AccountType
        {
            get
            {
                if (Account > 0) return "بدهکار";
                if (Account < 0) return "بستانکار";
                return "بی حساب";
            }
        }
        public string FirstNumber =>
            AsyncContext.Run(() => PhoneBookBussines.GetAllAsync(Guid, true))?.FirstOrDefault()?.Tell ?? "";
        private List<PhoneBookBussines> _tellList;
        public List<PhoneBookBussines> TellList
        {
            get
            {
                if (_tellList != null) return _tellList;
                _tellList = AsyncContext.Run(() => PhoneBookBussines.GetAllAsync(Guid, Status));
                return _tellList;
            }
            set => _tellList = value;
        }
        private List<PeoplesBankAccountBussines> _bankList;
        public List<PeoplesBankAccountBussines> BankList
        {
            get
            {
                if (_bankList != null) return _bankList;
                _bankList = AsyncContext.Run(() => PeoplesBankAccountBussines.GetAllAsync(Guid, Status));
                return _bankList;
            }
            set => _bankList = value;
        }

        public static async Task<List<PeoplesBussines>> GetAllAsync() => await UnitOfWork.Peoples.GetAllAsync();

        public static async Task<PeoplesBussines> GetAsync(Guid guid) => await UnitOfWork.Peoples.GetAsync(guid);

        public static async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.Peoples.GetAllAsync(parentGuid, status);

        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool sendToServer, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                if (TellList.Count > 0)
                {
                    var list = await PhoneBookBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.PhoneBook.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();

                    foreach (var item in TellList)
                    {
                        item.ParentGuid = Guid;
                        item.Name = Name;
                    }
                    res.AddReturnedValue(
                        await UnitOfWork.PhoneBook.SaveRangeAsync(TellList, tranName));
                    res.ThrowExceptionIfError();
                }

                if (BankList.Count > 0)
                {
                    var list = await PeoplesBankAccountBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.PeopleBankAccount.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    res.ThrowExceptionIfError();

                    foreach (var item in BankList)
                        item.ParentGuid = Guid;
                    res.AddReturnedValue(
                        await UnitOfWork.PeopleBankAccount.SaveRangeAsync(BankList, tranName));
                    res.ThrowExceptionIfError();
                }

                var gardesh = await GardeshHesabBussines.GetAsync(Guid, Guid.Empty, true);
                if (gardesh == null && AccountFirst != 0)
                {
                    var g = new GardeshHesabBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Babat = EnAccountBabat.Ins,
                        Description = "افتتاح حساب",
                        PeopleGuid = Guid,
                        Price = Account_,
                        ParentGuid = Guid.Empty
                    };

                    if (Account == 0) g.Type = EnAccountType.BiHesab;
                    if (Account > 0) g.Type = EnAccountType.Bed;
                    if (Account < 0) g.Type = EnAccountType.Bes;
                    res.AddReturnedValue(
                        await UnitOfWork.GardeshHesab.SaveAsync(g, tranName));
                    res.ThrowExceptionIfError();
                }
                else if (gardesh != null)
                {
                    gardesh.Price = Math.Abs(AccountFirst);
                    if (Account == 0) gardesh.Type = EnAccountType.BiHesab;
                    if (Account > 0) gardesh.Type = EnAccountType.Bed;
                    if (Account < 0) gardesh.Type = EnAccountType.Bes;
                    res.AddReturnedValue(
                        await UnitOfWork.GardeshHesab.SaveAsync(gardesh, tranName));
                    res.ThrowExceptionIfError();
                }

                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
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

        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, bool sendToServer, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                if (BankList.Count > 0)
                {
                    foreach (var item in BankList)
                    {
                        res.AddReturnedValue(
                            await item.ChangeStatusAsync(status, tranName));
                        res.ThrowExceptionIfError();
                    }
                }


                res.AddReturnedValue(await UnitOfWork.Peoples.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
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

        public static async Task<string> NextCodeAsync() => await UnitOfWork.Peoples.NextCodeAsync();

        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Peoples.CheckCodeAsync(code, guid);

        public static async Task<List<PeoplesBussines>> GetAllAsync(string search, Guid groupGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = new List<PeoplesBussines>();
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
                                                 x.Code.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res.OrderBy(q => q.Code).ToList();

                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PeoplesBussines>();
            }
        }

        public static async Task<bool> CheckNameAsync(string name) =>
            await UnitOfWork.Peoples.CheckNameAsync(name);

    }
}
