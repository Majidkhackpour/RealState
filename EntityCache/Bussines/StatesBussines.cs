using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class StatesBussines : IStates
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }

        public static async Task<List<StatesBussines>> GetAllAsync(CancellationToken token=default) => await UnitOfWork.States.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<StatesBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.States.SaveRangeAsync(list, tr));
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
        public static async Task<StatesBussines> GetAsync(Guid guid) => await UnitOfWork.States.GetAsync(Cache.ConnectionString, guid);
        public static async Task<StatesBussines> GetAsync(string name) => await UnitOfWork.States.GetAsync(Cache.ConnectionString, name);
        public static async Task<List<StatesBussines>> GetAllNotSentAsync()
            => await UnitOfWork.States.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.States.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<StatesBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = StateMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebStates.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(StatesBussines item)
            => await SendToServerAsync(new List<StatesBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.States.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            var uiUpdater = ClsCache.SendData2ServerInstance?.States;
            try
            {
                if (uiUpdater != null)
                {
                    uiUpdater.ShortMessage = "در حال ارسال استان ها";
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
                        uiUpdater.ShortMessage = $"استان جاری: {item?.Name}";
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
