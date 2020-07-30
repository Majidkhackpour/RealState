using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class PeoplesBankAccountBussines : IPeopleBankAccount
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Shobe { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.PeopleBankAccount.GetAllAsync(parentGuid, status);

        public static List<PeoplesBankAccountBussines> GetAll(Guid parentGuid, bool status) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid, status));

        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync() =>
            await UnitOfWork.PeopleBankAccount.GetAllAsync();


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

                res.AddReturnedValue(await UnitOfWork.PeopleBankAccount.ChangeStatusAsync(this, status, tranName));
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

        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid, string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync(parentGuid, true);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.Shobe.ToLower().Contains(item.ToLower()) ||
                                                 x.AccountNumber.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.BankName).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PeoplesBankAccountBussines>();
            }
        }

        public static List<PeoplesBankAccountBussines> GetAll(Guid parentGuid, string search) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid, search));
    }
}
