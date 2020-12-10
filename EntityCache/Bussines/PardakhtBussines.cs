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
    public class PardakhtBussines : IPardakht
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid Payer { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
        public string Time => CreateDate.ToShortTimeString();
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public decimal BankPrice { get; set; }
        public string FishNo { get; set; }
        public decimal Check { get; set; }
        public string CheckNo { get; set; }
        public string SarResid { get; set; }
        public string BankName { get; set; }
        public decimal TotalPrice => NaqdPrice + BankPrice + Check;


        public static async Task<List<PardakhtBussines>> GetAllAsync() => await UnitOfWork.Pardakht.GetAllAsync();

        public static async Task<List<PardakhtBussines>> GetAllAsync(Guid receptioGuid) =>
            await UnitOfWork.Pardakht.GetAllAsync(receptioGuid);
        public static async Task<PardakhtBussines> GetAsync(Guid guid) => await UnitOfWork.Pardakht.GetAsync(guid);

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

                res.AddReturnedValue(await UnitOfWork.Pardakht.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
                    _ = Task.Run(() => WebPardakht.SaveAsync(this));
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

                var gardesh = await GardeshHesabBussines.GetAsync(Payer, Guid, !status);
                if (gardesh != null)
                {
                    res.AddReturnedValue(await UnitOfWork.GardeshHesab.ChangeStatusAsync(gardesh, status, tranName));
                    res.ThrowExceptionIfError();
                }

                res.AddReturnedValue(await UnitOfWork.Pardakht.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
                    _ = Task.Run(() => WebPardakht.SaveAsync(this));
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

        public static async Task<List<PardakhtBussines>> GetAllAsync(string search, Guid receptorGuid)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync(receptorGuid);
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Description.ToLower().Contains(item.ToLower()) ||
                                                 x.NaqdPrice.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.BankName.ToLower().Contains(item.ToLower()) ||
                                                 x.BankPrice.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.Check.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.FishNo.ToLower().Contains(item.ToLower()) ||
                                                 x.CheckNo.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.CreateDate).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PardakhtBussines>();
            }
        }

        public static PardakhtBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
    }
}
