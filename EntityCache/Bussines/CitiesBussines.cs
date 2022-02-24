using EntityCache.Assistence;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Mppings;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class CitiesBussines : ICities
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public Guid StateGuid { get; set; }
        public string StateName { get; set; }
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


        public static async Task<List<CitiesBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Cities.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<CitiesBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.Cities.SaveRangeAsync(list, tr));
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
        public static async Task<List<CitiesBussines>> GetAllAsync(string search, Guid stateGuid, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = new List<CitiesBussines>();
                if (token.IsCancellationRequested) return null;
                if (stateGuid == Guid.Empty)
                    res = await GetAllAsync(token);
                else
                    res = await GetAllAsync(stateGuid, token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
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
                return new List<CitiesBussines>();
            }
        }
        public static async Task<CitiesBussines> GetAsync(Guid guid) => await UnitOfWork.Cities.GetAsync(Cache.ConnectionString, guid);
        public static async Task<CitiesBussines> GetAsync(string name) => await UnitOfWork.Cities.GetAsync(Cache.ConnectionString, name);
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

                res.AddReturnedValue(await UnitOfWork.Cities.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Cities, Guid, "", tr));
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
                res.AddReturnedValue(await UnitOfWork.Cities.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Cities, Guid, "", tr));
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
        public static async Task<bool> CheckNameAsync(Guid stateGuid, string name, Guid guid) =>
            await UnitOfWork.Cities.CheckNameAsync(Cache.ConnectionString, stateGuid, name, guid);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (StateGuid == Guid.Empty) res.AddError("استان نمی تواند خالی باشد");
                if (string.IsNullOrWhiteSpace(Name)) res.AddError("عنوان شهرستان نمی تواند خالی باشد");
                if (!await CheckNameAsync(StateGuid, Name, Guid)) res.AddError("عنوان شهرستان در این استان، تکراری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<CitiesBussines>> GetAllAsync(Guid stateGuid, CancellationToken token) =>
            await UnitOfWork.Cities.GetAllAsync(Cache.ConnectionString, stateGuid, token);
        public static async Task<CitiesBussines> GetDefualtAsync(string name, Guid stateGuid)
        {
            try
            {
                var c = await GetAsync(name);
                if (c != null && c.Guid != Guid.Empty) return c;
                var state = await StatesBussines.GetAsync(stateGuid);
                if (state == null) return null;
                c = new CitiesBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = name,
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now,
                    StateGuid = stateGuid
                };
                await c.SaveAsync();
                return c;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public static async Task<List<CitiesBussines>> GetAllNotSentAsync()
            => await UnitOfWork.Cities.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.Cities.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<CitiesBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = CityMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebCity.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(CitiesBussines item)
            => await SendToServerAsync(new List<CitiesBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.Cities.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            var uiUpdater = ClsCache.SendData2ServerInstance?.City;
            try
            {
                if (uiUpdater != null)
                {
                    uiUpdater.ShortMessage = "در حال ارسال شهرها";
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
                        uiUpdater.ShortMessage = $"شهر جاری: {item?.Name}";
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
