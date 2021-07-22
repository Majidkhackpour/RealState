﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class SanadBussines : ISanad
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public DateTime DateM { get; set; } = DateTime.Now;
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
        public string HardSerial => Cache.HardSerial;
        public List<SanadDetailBussines> Details { get; set; }


        public static async Task<List<SanadBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Sanad.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<SanadBussines> GetAsync(Guid guid) => await UnitOfWork.Sanad.GetAsync(Cache.ConnectionString, guid);
        public static SanadBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<SanadBussines> GetAsync(long number) => await UnitOfWork.Sanad.GetAsync(Cache.ConnectionString, number);
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

                res.AddReturnedValue(await CheckvalidationAsync());
                if (res.HasError) return res;

                var oldSanad = await GetAsync(Guid);
                if (oldSanad != null)
                {
                    res.AddReturnedValue(await UpdateAccounts(oldSanad.Details, true, tr));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.Sanad.SaveAsync(this, tr));
                if (res.HasError) return res;
                foreach (var item in Details) item.MasterGuid = Guid;
                res.AddReturnedValue(await SanadDetailBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await SanadDetailBussines.SaveRangeAsync(Details, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UpdateAccounts(Details, false, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebSanad.SaveAsync(this));
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

                res.AddReturnedValue(await UpdateAccounts(Details, true, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await SanadDetailBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Sanad.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebRental.SaveAsync(list));
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
        private static async Task<ReturnedSaveFuncInfo> UpdateAccounts(List<SanadDetailBussines> dets, bool isRemove, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in dets)
                {
                    var tafsil = await TafsilBussines.GetAsync(item.TafsilGuid, tr);
                    var moein = await MoeinBussines.GetAsync(item.MoeinGuid, tr);
                    decimal price = 0;
                    var tag = 1;
                    if (isRemove) tag *= -1;

                    if (item.Debit > 0) price = -item.Debit * tag;
                    else if (item.Credit > 0) price = item.Credit * tag;
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

                    res.AddReturnedValue(await moein.UpdateAccountAsync(price, tr));
                    res.AddReturnedValue(await tafsil.UpdateAccountAsync(price, tr));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public ReturnedSaveFuncInfo AddToListSanad(SanadDetailBussines sanadDetBusiness)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(sanadDetBusiness.CheckValidation());
                if (res.HasError) return res;
                sanadDetBusiness.MasterGuid = Guid;
                if (Details == null) Details = new List<SanadDetailBussines>();
                var old = Details.FirstOrDefault(q => q.Guid == sanadDetBusiness.Guid);
                if (old != null)
                    Details.Remove(old);
                Details.Add(sanadDetBusiness);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public void RemoveFromListSanad(Guid guid)
        {
            try
            {
                if (Details == null) Details = new List<SanadDetailBussines>();
                var item = Details.FirstOrDefault(p => p.Guid == guid);
                if (item != null) Details.Remove(item);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public ReturnedSaveFuncInfo AddRangeToListSanad(List<SanadDetailBussines> sanaddet)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (Details == null) Details = new List<SanadDetailBussines>();
                foreach (var det in Details)
                    if (det != null)
                    {
                        res.AddReturnedValue(AddToListSanad(det));
                        if (res.HasError) return res;
                    }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<SanadBussines>> GetAllAsync(string search, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Number.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SanadTypeName.ToLower().Contains(item.ToLower()) ||
                                                 x.SanadStatusName.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.Description.ToLower().Contains(item.ToLower()) ||
                                                 x.SumDebit.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.SumCredit.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderByDescending(o => o.Number).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<SanadBussines>();
            }
        }
        public static async Task<long> NextNumberAsync() => await UnitOfWork.Sanad.NextNumberAsync(Cache.ConnectionString);
        public static long NextNumber() => AsyncContext.Run(NextNumberAsync);
        public async Task<bool> CheckCodeAsync(Guid guid, long code) => await UnitOfWork.Sanad.CheckCodeAsync(Cache.ConnectionString, guid, code);
        private async Task<ReturnedSaveFuncInfo> CheckvalidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Description)) res.AddError("لطفا شرح سند را وارد نمایید");
                if (SumCredit == 0 && SumDebit == 0) res.AddError("سند بدون سطر قابل درج نمی باشد");
                if (SumCredit != SumDebit) res.AddError("سند موازنه نمی باشد");
                if (!await CheckCodeAsync(Guid, Number)) res.AddError("شماره سند معتبر نمی باشد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public void DetailClear() => Details?.Clear();
    }
}
