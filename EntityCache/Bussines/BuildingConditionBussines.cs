﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingConditionBussines : IBuildingCondition
    {
        private static Guid _defualtGuid = Guid.Empty;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
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


        public static async Task<List<BuildingConditionBussines>> GetAllAsync(CancellationToken token = default) => await UnitOfWork.BuildingCondition.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingConditionBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingCondition.SaveRangeAsync(list, tr));
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
        public static async Task<BuildingConditionBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingCondition.GetAsync(Cache.ConnectionString, guid);
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

                res.AddReturnedValue(await UnitOfWork.BuildingCondition.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingCondition, Guid, "", tr));
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
                res.AddReturnedValue(await UnitOfWork.BuildingCondition.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingCondition, Guid, "", tr));
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
        public static async Task<List<BuildingConditionBussines>> GetAllAsync(string search, CancellationToken token)
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
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()))
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
                return new List<BuildingConditionBussines>();
            }
        }
        public static async Task<bool> CheckNameAsync(string name, Guid guid) =>
            await UnitOfWork.BuildingCondition.CheckNameAsync(Cache.ConnectionString, name, guid);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(Name)) res.AddError("عنوان نمی تواند خالی باشد");
                if (!await CheckNameAsync(Name.Trim(), Guid)) res.AddError("عنوان وارد شده تکراری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<Guid> GetDefultGuidAsync(string name = "تعیین نشده")
        {
            try
            {
                var list = await GetAllAsync(name, new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingConditionBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = name,
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now
                };
                await def.SaveAsync();

                return def.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
        public static async Task<List<BuildingConditionBussines>> GetAllNotSentAsync()
            => await UnitOfWork.BuildingCondition.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.BuildingCondition.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingConditionBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = BuildingConditionMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebBuildingCondition.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingConditionBussines item)
            => await SendToServerAsync(new List<BuildingConditionBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.BuildingCondition.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var list = await GetAllNotSentAsync();
                if (list == null || list.Count <= 0) return res;
                foreach (var item in list)
                    res.AddReturnedValue(await SendToServerAsync(item));
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
