using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using PacketParser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class CitiesBussines : ICities
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public Guid StateGuid { get; set; }
        public string StateName { get; set; }


        public static async Task<List<CitiesBussines>> GetAllAsync() => await UnitOfWork.Cities.GetAllAsyncBySp();

        public static async Task<List<CitiesBussines>> GetAllAsyncEf() => await UnitOfWork.Cities.GetAllAsync();
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<CitiesBussines> list,
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

                res.AddReturnedValue(await UnitOfWork.Cities.SaveRangeAsync(list, tranName));
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


        public static async Task<List<CitiesBussines>> GetAllAsync(string search, Guid stateGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = new List<CitiesBussines>();
                if (stateGuid == Guid.Empty)
                    res = await GetAllAsync();
                else
                    res = await GetAllAsync(stateGuid);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.StateName.ToLower().Contains(item.ToLower()))
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
                return new List<CitiesBussines>();
            }
        }


        public static async Task<CitiesBussines> GetAsync(Guid guid) => await UnitOfWork.Cities.GetAsync(guid);

        public static CitiesBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.Cities.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.Cities.ChangeStatusAsync(this, status, tranName));
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

        public static async Task<bool> CheckNameAsync(Guid stateGuid, string name, Guid guid) =>
            await UnitOfWork.Cities.CheckNameAsync(stateGuid, name, guid);

        public static List<CitiesBussines> GetAll() => AsyncContext.Run(GetAllAsync);

        public static async Task<List<CitiesBussines>> GetAllAsync(Guid stateGuid) =>
            await UnitOfWork.Cities.GetAllAsync(stateGuid);

        public static List<CitiesBussines> GetAll(string search, Guid stateGuid) =>
            AsyncContext.Run(() => GetAllAsync(search, stateGuid));
    }
}
