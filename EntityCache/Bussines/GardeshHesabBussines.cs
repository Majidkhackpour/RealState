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
    public class GardeshHesabBussines : IGardeshHesab
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(Modified);
        public string Time => Modified.ToShortTimeString();
        public bool Status { get; set; } = true;
        public Guid PeopleGuid { get; set; }
        public decimal Price { get; set; }
        public EnAccountType Type { get; set; }
        public string TypeName => Type.GetDisplay();
        public EnAccountBabat Babat { get; set; }
        public string BabatName => Babat.GetDisplay();
        public string Description { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<List<GardeshHesabBussines>> GetAllAsync() => await UnitOfWork.GardeshHesab.GetAllBySpAsync();

        public static async Task<GardeshHesabBussines> GetAsync(Guid guid) => await UnitOfWork.GardeshHesab.GetAsync(guid);

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

                res.AddReturnedValue(await UnitOfWork.GardeshHesab.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.GardeshHesab.ChangeStatusAsync(this, status, tranName));
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

        public static async Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid, string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync(hesabGuid);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.TypeName.ToLower().Contains(item.ToLower()) ||
                                                 x.BabatName.ToLower().Contains(item.ToLower()) ||
                                                 x.Price.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.Modified).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<GardeshHesabBussines>();
            }
        }

        public static GardeshHesabBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public static async Task<GardeshHesabBussines> GetAsync(Guid hesabGuid, Guid parentGuid,bool status) =>
            await UnitOfWork.GardeshHesab.GetAsync(hesabGuid, parentGuid, status);

        public static async Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid) =>
            await UnitOfWork.GardeshHesab.GetAllAsync(hesabGuid);

        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<GardeshHesabBussines> list,
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

                res.AddReturnedValue(await UnitOfWork.GardeshHesab.SaveRangeAsync(list, tranName));
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

        public static async Task<List<GardeshHesabBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.GardeshHesab.GetAllAsync(parentGuid, status);

        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(List<Guid> list,
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

                res.AddReturnedValue(await UnitOfWork.GardeshHesab.RemoveRangeAsync(list, tranName));
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
    }
}
