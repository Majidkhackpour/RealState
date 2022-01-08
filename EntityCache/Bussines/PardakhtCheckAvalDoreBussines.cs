using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.DefaultCoding;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class PardakhtCheckAvalDoreBussines : IPardakhtCheckAvalDore
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string DasteCheckName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateSarresid { get; set; } = DateTime.Now;
        public string DateSarresidSh => Calendar.MiladiToShamsi(DateSarresid);
        public string Number { get; set; }
        public Guid CheckPageGuid { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }


        public static async Task<List<PardakhtCheckAvalDoreBussines>> GetAllAsync() =>
            await UnitOfWork.PardakhtCheckAvalDore.GetAllAsync(Cache.ConnectionString);
        public static async Task<PardakhtCheckAvalDoreBussines> GetAsync(Guid guid) =>
            await UnitOfWork.PardakhtCheckAvalDore.GetAsync(Cache.ConnectionString, guid);
        public static PardakhtCheckAvalDoreBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool isUpdateAccount, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                var oldSanad = await GetAsync(Guid);
                if (oldSanad != null)
                {
                    var check = await CheckPageBussines.GetAsync(oldSanad.CheckPageGuid);
                    check.CheckStatus = EnCheckSh.Mojoud;
                    check.DatePardakht = null;
                    check.DateSarresid = null;
                    check.Description = "";
                    check.Modified = DateTime.Now;
                    check.Price = 0;
                    check.ReceptorGuid = null;
                    res.AddReturnedValue(await check.SaveAsync(tr));
                    if (res.HasError) return res;
                }

                if (isUpdateAccount)
                {
                    if (oldSanad != null)
                    {
                        res.AddReturnedValue(await UpdateAccountsAsync(oldSanad, true, tr));
                        if (res.HasError) return res;
                    }
                }


                var checkPage = await CheckPageBussines.GetAsync(CheckPageGuid);
                checkPage.CheckStatus = EnCheckSh.KharjShode;
                checkPage.DatePardakht = DateTime.Now;
                checkPage.DateSarresid = DateSarresid;
                checkPage.Description = Description;
                checkPage.Modified = DateTime.Now;
                checkPage.Price = Price;
                checkPage.ReceptorGuid = TafsilGuid;
                res.AddReturnedValue(await checkPage.SaveAsync(tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckAvalDore.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (isUpdateAccount)
                {
                    res.AddReturnedValue(await UpdateAccountsAsync(this, false, tr));
                    if (res.HasError) return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                res.AddReturnedValue(await UpdateAccountsAsync(this, true, tr));
                if (res.HasError) return res;

                var check = await CheckPageBussines.GetAsync(CheckPageGuid);
                check.CheckStatus = EnCheckSh.Mojoud;
                check.DatePardakht = null;
                check.DateSarresid = null;
                check.Description = "";
                check.Modified = DateTime.Now;
                check.Price = 0;
                check.ReceptorGuid = null;
                res.AddReturnedValue(await check.SaveAsync());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.PardakhtCheckAvalDore.RemoveAsync(Guid, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (Price <= 0) res.AddError("لطفا مبلغ را وارد نمایید");
                if (string.IsNullOrEmpty(DasteCheckName)) res.AddError("لطفا دسته چک را وارد نمایید");
                if (CheckPageGuid == Guid.Empty) res.AddError("لطفا برگه چک را انتخاب نمایید");
                if (TafsilGuid == Guid.Empty) res.AddError("لطفا پردازنده چک را انتخاب نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<ReturnedSaveFuncInfo> UpdateAccountsAsync(PardakhtCheckAvalDoreBussines item, bool isRemove, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var checkPage = await CheckPageBussines.GetAsync(item.CheckPageGuid);
                var dasteCheck = await DasteCheckBussines.GetAsync(checkPage.CheckGuid);
                var tafsil = await TafsilBussines.GetAsync(dasteCheck.BankGuid);
                var moein = await MoeinBussines.GetAsync(ParentDefaults.MoeinCoding.CLSMoein30101);
                decimal price = 0;
                var tag = 1;
                if (isRemove) tag *= -1;

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

                res.AddReturnedValue(await moein.UpdateAccountAsync(price, tr));
                res.AddReturnedValue(await tafsil.UpdateAccountAsync(price, tr));
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
