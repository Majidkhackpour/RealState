using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using Services;

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
        private List<PhoneBookBussines> _tellList;
        public List<PhoneBookBussines> TellList
        {
            get
            {
                if (_tellList != null) return _tellList;
                _tellList = PhoneBookBussines.GetAll(Guid, Status);
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
                _bankList = PeoplesBankAccountBussines.GetAll(Guid, Status);
                return _bankList;
            }
            set => _bankList = value;
        }

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

                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
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

        public static List<PeoplesBussines> GetAll() => AsyncContext.Run(GetAllAsync);

        public static async Task<string> NextCodeAsync() => await UnitOfWork.Peoples.NextCodeAsync();

        public static string NextCode() => AsyncContext.Run(NextCodeAsync);

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

        public static List<PeoplesBussines> GetAll(string search, Guid groupGuid) =>
            AsyncContext.Run(() => GetAllAsync(search, groupGuid));
    }
}
