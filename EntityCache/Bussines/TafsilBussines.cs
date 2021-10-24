using EntityCache.Assistence;
using Nito.AsyncEx;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Mppings;
using Persistence;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class TafsilBussines : ITafsil
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; } = DateTime.Now;
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public bool isSystem { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string Diagnosis => Account.AccountDiagnosis();


        public static async Task<List<TafsilBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Tafsil.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<TafsilBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Tafsil.SaveRangeAsync(list, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebTafsil.SaveAsync(TafsilMapper.Instance.MapList(list)));
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

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Tafsil.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebTafsil.SaveAsync(TafsilMapper.Instance.Map(this)));
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
        public static async Task<TafsilBussines> GetAsync(Guid guid, SqlTransaction tr = null) => await UnitOfWork.Tafsil.GetAsync(Cache.ConnectionString, guid, tr);
        public static async Task<List<TafsilBussines>> GetAllAsync(string search, CancellationToken token, HesabType htype = HesabType.All)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                if (htype != HesabType.All) res = res.Where(q => q.HesabType == htype).ToList();
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.Account.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<TafsilBussines>();
            }
        }
        public static TafsilBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<string> NextCodeAsync(HesabType hType) => await UnitOfWork.Tafsil.NextCodeAsync(Cache.ConnectionString, hType);
        public static string NextCode(HesabType hType) => AsyncContext.Run(() => NextCodeAsync(hType));
        public async Task<bool> CheckCodeAsync(Guid guid, string code) => await UnitOfWork.Tafsil.CheckCodeAsync(Cache.ConnectionString, guid, code);
        public static async Task<bool> CheckNameAsync(string name) => await UnitOfWork.Tafsil.CheckNameAsync(Cache.ConnectionString, name);
        public async Task<ReturnedSaveFuncInfo> UpdateAccountAsync(decimal price, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Tafsil.UpdateAccountAsync(Guid, price, tr));
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
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان حساب نمی تواند خالی باشد");
                if (string.IsNullOrEmpty(Code)) res.AddError("کد حساب نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Guid, Code)) res.AddError("کد حساب معتبر نمی باشد");
                if (HesabType == HesabType.Bank || HesabType == HesabType.Sandouq)
                    if (Account > 0)
                        res.AddError("ماهیت حساب بانک و صندوق بدهکار است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Tafsil.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebTafsil.SaveAsync(TafsilMapper.Instance.Map(this)));
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
        public static async Task<TafsilBussines> GetAsync(string code) => await UnitOfWork.Tafsil.GetAsync(Cache.ConnectionString, code);
        public static TafsilBussines Get(string code) => AsyncContext.Run(() => GetAsync(code));
    }
}
