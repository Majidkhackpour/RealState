﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using EntityCache.ViewModels;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class RegionsBussines : IRegions
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public Guid CityGuid { get; set; }
        public Guid StateGuid { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public bool IsChecked { get; set; }
        public bool IsModified { get; set; } = false;
        public byte[] ServerStatusImage
        {
            get
            {
                if (ServerStatus == ServerStatus.Delivered || ServerStatus == ServerStatus.DirectDelivery)
                    return ImageResourceManager.ServerStatusDelivered;
                if (ServerStatus == ServerStatus.DeliveryError)
                    return ImageResourceManager.ServerStatusDeliveryFailed;
                if (ServerStatus == ServerStatus.Sent)
                    return ImageResourceManager.ServerStatusSent;
                if (ServerStatus == ServerStatus.SendError)
                    return ImageResourceManager.ServerStatusSentError;
                return ImageResourceManager.ServerStatusNone;
            }
        }

        public static async Task<List<RegionsBussines>> GetAllAsync(CancellationToken token=default) => await UnitOfWork.Regions.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<RegionsBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Regions.SaveRangeAsync(list, tr));
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

                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(list));
            }
            return res;
        }
        public static async Task<RegionsBussines> GetAsync(Guid guid) => await UnitOfWork.Regions.GetAsync(Cache.ConnectionString, guid);
        public static async Task<RegionsBussines> GetAsync(string name) => await UnitOfWork.Regions.GetAsync(Cache.ConnectionString, name);
        public static async Task<List<RegionsBussines>> GetAllAsync(string search, Guid cityGuid, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = new List<RegionsBussines>();
                if (token.IsCancellationRequested) return null;
                if (cityGuid == Guid.Empty) res = await GetAllAsync(token);
                else res = await GetAllAsync(cityGuid, token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.CityName.ToLower().Contains(item.ToLower()) ||
                                                 x.StateName.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<RegionsBussines>();
            }
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

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Regions.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Regions, Guid, "", tr));
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
                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(this));
            }
            return res;
        }
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (CityGuid == Guid.Empty) res.AddError("شهرستان نمی تواند خالی باشد");
                if (string.IsNullOrWhiteSpace(Name)) res.AddError("عنوان منطقه نمی تواند خالی باشد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
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

                ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await UnitOfWork.Regions.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Regions, Guid, "", tr));
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
                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(this));
            }
            return res;
        }
        public static async Task<List<RegionsBussines>> GetAllAsync(Guid cityGuid, CancellationToken token=default) =>
            await UnitOfWork.Regions.GetAllAsync(Cache.ConnectionString, cityGuid, token);
        public static async Task<List<RegionReportViewModel>> GetAllBuildingReportAsync(CancellationToken token) => await UnitOfWork.Regions.GetAllBuildingReportAsync(Cache.ConnectionString, token);
        public static async Task<List<RegionReportViewModel>> GetAllRequestReportAsync(CancellationToken token) => await UnitOfWork.Regions.GetAllRequestReportAsync(Cache.ConnectionString, token);
        public static async Task<RegionsBussines> GetDefualtAsync(string name, Guid cityGuid)
        {
            try
            {
                var reg = await GetAsync(name);
                if (reg != null && reg.Guid != Guid.Empty) return reg;
                var city = await CitiesBussines.GetAsync(cityGuid);
                if (city == null) return null;
                reg = new RegionsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = name,
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now,
                    CityGuid = cityGuid,
                    StateGuid = city.StateGuid
                };
                await reg.SaveAsync();
                return reg;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task<List<RegionsBussines>> GetAllNotSentAsync()
            => await UnitOfWork.Regions.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.Regions.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<RegionsBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = RegionMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebRegion.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(RegionsBussines item)
            => await SendToServerAsync(new List<RegionsBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.Regions.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            var uiUpdater = ClsCache.SendData2ServerInstance?.Region;
            try
            {
                if (uiUpdater != null)
                {
                    uiUpdater.ShortMessage = "در حال ارسال مناطق";
                    uiUpdater.Status = SyncStatus.Syncing;
                    uiUpdater.FinalStatus = res;
                }

                var list = await GetAllNotSentAsync();
                if (list == null || list.Count <= 0) return res;
                if (uiUpdater != null) uiUpdater.TotalCount = list?.Count ?? 0;
                var current = 0;
                foreach (var item in list)
                {
                    current++;
                    if (uiUpdater != null)
                    {
                        uiUpdater.ShortMessage = $"منطقه جاری: {item?.Name}";
                        uiUpdater.Count = current;
                    }

                    res.AddReturnedValue(await SendToServerAsync(item));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (uiUpdater != null)
                {
                    if (res.HasError)
                    {
                        uiUpdater.ShortMessage = "با شکست مواجه شد";
                        uiUpdater.Status = SyncStatus.SyncFailed;
                    }
                    else
                    {
                        uiUpdater.ShortMessage = "با موفقیت انجام شد.";
                        uiUpdater.Status = SyncStatus.SyncedOk;
                    }
                }
            }
            return res;
        }
    }
}
