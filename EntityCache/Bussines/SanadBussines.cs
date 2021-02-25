using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SanadBussines : ISanad
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public string Description { get; set; }
        public long Number { get; set; }
        public EnSanadStatus SanadStatus { get; set; }
        public string SanadStatusName => SanadStatus.GetDisplay();
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public decimal SumDebit
        {
            get
            {
                if (Details == null || Details.Count <= 0) return 0;
                return Details.Sum(q => q.Debit);
            }
        }
        public decimal SumCredit
        {
            get
            {
                if (Details == null || Details.Count <= 0) return 0;
                return Details.Sum(q => q.Credit);
            }
        }
        public EnSanadType SanadType { get; set; }
        public string SanadTypeName => SanadType.GetDisplay();
        public List<SanadDetailBussines> Details { get; set; }


        public static async Task<List<SanadBussines>> GetAllAsync() => await UnitOfWork.Sanad.GetAllAsync();
        public async Task<SanadBussines> GetAsync(Guid guid) => await UnitOfWork.Sanad.GetAsync(guid);
        public async Task<SanadBussines> GetAsync(long number) => await UnitOfWork.Sanad.GetAsync(number);
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


                res.AddReturnedValue(await UnitOfWork.Sanad.SaveAsync(this, tranName));
                if (res.HasError) return res;
                foreach (var item in Details) item.MasterGuid = Guid;
                res.AddReturnedValue(await SanadDetailBussines.SaveRangeAsync(Details, tranName));
                if (res.HasError) return res;
                res.AddReturnedValue(await UpdateTafsilAccounts(false));
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
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(await UpdateTafsilAccounts(true));
                if (res.HasError) return res;
                res.AddReturnedValue(await SanadDetailBussines.RemoveRangeAsync(Guid, tranName));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Sanad.RemoveAsync(Guid, tranName));
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
        private async Task<ReturnedSaveFuncInfo> UpdateTafsilAccounts(bool isRemove)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in Details)
                {
                    var tafsil = await TafsilBussines.GetAsync(item.TafsilGuid);
                    var moein = await MoeinBussines.GetAsync(item.MoeinGuid);
                    decimal price = 0;
                    var tag = 1;
                    if (isRemove) tag *= -1;

                    if (item.Debit > 0) price = item.Debit * tag;
                    else if (SumCredit > 0) price = item.Credit * tag;
                    else
                    {
                        res.AddError("مبلغ نامعتبر");
                        return res;
                    }

                    if (moein == null)
                    {
                        res.AddError("حساب معین نامعتبر");
                        return res;
                    }
                    if (tafsil == null)
                    {
                        res.AddError("حساب تفصیلی نامعتبر");
                        return res;
                    }

                    res.AddReturnedValue(await moein.UpdateAccountAsync(price));
                    res.AddReturnedValue(await tafsil.UpdateAccountAsync(price));
                }
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
