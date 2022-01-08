using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using EntityCache.ViewModels;
using Persistence;
using Services;
using Services.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class SanadDetailBussines : ISanadDetails
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public Guid MasterGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public string MoeinCode { get; set; }
        public string MoeinName { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilCode { get; set; }
        public string TafsilName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }


        public static async Task<List<SanadDetailBussines>> GetAllAsync(Guid masterGuid) => await UnitOfWork.SanadDetail.GetAllAsync(Cache.ConnectionString, masterGuid);
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.SanadDetail.SaveAsync(this, tr));
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
        public static async Task<SanadDetailBussines> GetAsync(Guid guid) =>
            await UnitOfWork.SanadDetail.GetAsync(Cache.ConnectionString, guid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<SanadDetailBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.SanadDetail.SaveRangeAsync(list, tr));
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
        public static async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.SanadDetail.RemoveRangeAsync(masterGuid, tr));
                if (res.HasError) return res;
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
        public static async Task<List<TarazAzmayeshiViewModel>> GetAllTarazAzmayeshiAsync(CancellationToken token) =>
            await UnitOfWork.SanadDetail.GetAllTarazAzmayeshiAsync(Cache.ConnectionString, token);
        public static async Task<List<TarazHesabViewModel>> GetAllTarazHesabAsync(CancellationToken token, DateTime d1, DateTime d2, long code1 = 0, long code2 = 0) =>
            await UnitOfWork.SanadDetail.GetAllTarazHesabAsync(Cache.ConnectionString, d1, d2, code1, code2, token);
        public ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (MoeinGuid == Guid.Empty)
                {
                    res.AddError("وارد کردن حساب معین الزامی است");
                    return res;
                }
                if (TafsilGuid == Guid.Empty)
                {
                    res.AddError("وارد کردن حساب تفصیلی الزامی است");
                    return res;
                }
                if (string.IsNullOrEmpty(Description))
                {
                    res.AddError("وارد کردن شرح سطر الزامی است");
                    return res;
                }
                if (Debit == 0 && Credit == 0)
                {
                    res.AddError("وارد کردن مبلغ بدهکار یا بستانکار الزامی است");
                    return res;
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
