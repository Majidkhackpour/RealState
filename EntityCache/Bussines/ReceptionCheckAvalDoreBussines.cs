using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.DefaultCoding;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class ReceptionCheckAvalDoreBussines : IReceptionCheckAvalDore
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string BankName { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public DateTime DateSarResid { get; set; } = DateTime.Now;
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarResid);
        public string Description { get; set; }
        public string CheckNumber { get; set; }
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public Guid SandouqTafsilGuid { get; set; }
        public string SandouqName { get; set; }
        public Guid SandouqMoeinGuid { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }


        public static async Task<List<ReceptionCheckAvalDoreBussines>> GetAllAsync() =>
            await UnitOfWork.ReceptionCheckAvalDore.GetAllAsync();
        public static async Task<ReceptionCheckAvalDoreBussines> GetAsync(Guid guid) =>
            await UnitOfWork.ReceptionCheckAvalDore.GetAsync(guid);
        public static ReceptionCheckAvalDoreBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool isUpdateAccount, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                if (isUpdateAccount)
                {
                    var oldSanad = await GetAsync(Guid);
                    if (oldSanad != null)
                    {
                        res.AddReturnedValue(await UpdateAccountsAsync(oldSanad, true));
                        if (res.HasError) return res;
                    }
                }

                res.AddReturnedValue(await UnitOfWork.ReceptionCheckAvalDore.SaveAsync(this, tranName));
                if (res.HasError) return res;

                if (isUpdateAccount)
                {
                    res.AddReturnedValue(await UpdateAccountsAsync(this, false));
                    if (res.HasError) return res;
                }

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
                {
                    //BeginTransaction
                }

                res.AddReturnedValue(await UpdateAccountsAsync(this, true));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.ReceptionCheckAvalDore.RemoveAsync(Guid, tranName));
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
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (Price <= 0) res.AddError("لطفا مبلغ را وارد نمایید");
                if (string.IsNullOrEmpty(BankName)) res.AddError("لطفا بانک صادر کننده چک را وارد نمایید");
                if (string.IsNullOrEmpty(CheckNumber)) res.AddError("لطفا شماره چک را وارد نمایید");
                if (SandouqTafsilGuid == Guid.Empty) res.AddError("لطفا صندوق مقصد را انتخاب نمایید");
                if (TafsilGuid == Guid.Empty) res.AddError("لطفا پردازنده چک را انتخاب نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> UpdateAccountsAsync(ReceptionCheckAvalDoreBussines item, bool isRemove)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tafsil = await TafsilBussines.GetAsync(item.SandouqTafsilGuid);
                var moein = await MoeinBussines.GetAsync(ParentDefaults.MoeinCoding.CLSMoein10104);
                decimal price = 0;
                var tag = 1;
                if (!isRemove) tag *= -1;

                price = item.Price * tag;

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
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
