using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingRelatedOptionsBussines : Serializable<BuildingRelatedOptionsBussines>, IBuildingRelatedOptions
    {
        public Guid Guid { get; set; }
        public Guid BuildinGuid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public Guid BuildingOptionGuid { get; set; }
        public string OptionName => BuildingOptionsBussines.Get(BuildingOptionGuid).Name;


        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.BuildingRelatedOptions.GetAllAsync(Cache.ConnectionString, parentGuid);
        public static List<BuildingRelatedOptionsBussines> GetAll(Guid parentGuid) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid));
        public static async Task<BuildingRelatedOptionsBussines> GetAsync(Guid guid) =>
            await UnitOfWork.BuildingRelatedOptions.GetAsync(Cache.ConnectionString, guid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingRelatedOptionsBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.SaveRangeAsync(list, tr));
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

                res.AddReturnedValue(await UnitOfWork.BuildingRelatedOptions.RemoveRangeAsync(masterGuid, tr));
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
        public static async Task<List<BuildingRelatedOptionsBussines>> GetAllNotSentAsync()
            => await UnitOfWork.BuildingRelatedOptions.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.BuildingRelatedOptions.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingRelatedOptionsBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = BuildingRelatedOptionMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebBuildingRelatedOptions.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingRelatedOptionsBussines item)
            => await SendToServerAsync(new List<BuildingRelatedOptionsBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.BuildingRelatedOptions.ResetAsync(Cache.ConnectionString);
    }
}
