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
    public class HazineBussines : IHazine
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string HardSerial => Cache.HardSerial;


        public static async Task<List<HazineBussines>> GetAllAsync() => await UnitOfWork.Hazine.GetAllAsync();

        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<HazineBussines> list,bool sendToServer,
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

                res.AddReturnedValue(await UnitOfWork.Hazine.SaveRangeAsync(list, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
                if (sendToServer)
                    _ = Task.Run(() => WebHazine.SaveAsync(list));
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

        public static async Task<HazineBussines> GetAsync(Guid guid) => await UnitOfWork.Hazine.GetAsync(guid);


        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool setEftetah, bool sendToServer, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                var gardesh = await GardeshHesabBussines.GetAsync(Guid, Guid.Empty, true);
                if (setEftetah)
                {
                    if (gardesh == null)
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
                    else
                    {
                        gardesh.Price = Math.Abs(AccountFirst);
                        if (Account == 0) gardesh.Type = EnAccountType.BiHesab;
                        if (Account > 0) gardesh.Type = EnAccountType.Bed;
                        if (Account < 0) gardesh.Type = EnAccountType.Bes;
                        res.AddReturnedValue(
                            await UnitOfWork.GardeshHesab.SaveAsync(gardesh, tranName));
                        res.ThrowExceptionIfError();
                    }
                }
                

                res.AddReturnedValue(await UnitOfWork.Hazine.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
                    _ = Task.Run(() => WebHazine.SaveAsync(this));
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

                res.AddReturnedValue(await UnitOfWork.Hazine.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
                    _ = Task.Run(() => WebHazine.SaveAsync(this));
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

        public static async Task<List<HazineBussines>> GetAllAsync(string search)
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
                return new List<HazineBussines>();
            }
        }

        public static HazineBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public static async Task<bool> CheckNameAsync(string name, Guid guid) =>
            await UnitOfWork.Hazine.CheckNameAsync(name, guid);
    }
}
