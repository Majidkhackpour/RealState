using EntityCache.Assistence;
using EntityCache.Mppings;
using Persistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingReviewBussines : IBuildingReview
    {
        public static event Func<Task> OnSaved;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid CustometGuid { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public bool IsModified { get; set; } = false;

        public static async Task<BuildingReviewBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingReview.GetAsync(Cache.ConnectionString, guid);
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
                res.AddReturnedValue(await UnitOfWork.BuildingReview.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingReview, Guid, "", tr));

                RaiseEvent();
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
                if (BuildingGuid == Guid.Empty) res.AddError("لطفا ملک مورد تقاضا را انتخاب نمایید");
                if (CustometGuid == Guid.Empty) res.AddError("لطفا بازدیدکننده را انتخاب نمایید");
                if (UserGuid == Guid.Empty) res.AddError("لطفا مامور بازدید را انتخاب نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStataus(bool status, SqlTransaction tr = null)
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
                res.AddReturnedValue(await UnitOfWork.BuildingReview.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingReview, Guid, "", tr));

                RaiseEvent();
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
        public static async Task<List<BuildingReviewBussines>> GetAllNotSentAsync()
            => await UnitOfWork.BuildingReview.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.BuildingReview.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingReviewBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = BuildingReviewMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebBuildingReview.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingReviewBussines item)
            => await SendToServerAsync(new List<BuildingReviewBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.BuildingReview.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            var uiUpdater = ClsCache.SendData2ServerInstance?.BuildingReview;
            try
            {
                if (uiUpdater != null)
                {
                    uiUpdater.ShortMessage = "در حال ارسال درخواست بازدیدها";
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
                    if (uiUpdater != null) uiUpdater.Count = current;
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
        private void RaiseEvent()
        {
            try
            {
                var handler = OnSaved;
                if (handler != null) OnSaved?.Invoke();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
    }
}
