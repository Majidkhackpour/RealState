using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingNoteBussines : Serializable<BuildingNoteBussines>, IBuildingNote
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }


        public static async Task<List<BuildingNoteBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.BuildingNotes.GetAllAsync(Cache.ConnectionString, parentGuid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingNoteBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingNotes.SaveRangeAsync(list, tr));
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

                res.AddReturnedValue(await UnitOfWork.BuildingNotes.RemoveRangeAsync(masterGuid, tr));
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
        public static async Task<List<BuildingNoteBussines>> GetAllNotSentAsync()
            => await UnitOfWork.BuildingNotes.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.BuildingNotes.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingNoteBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                //foreach (var item in list)
                //{
                //    var web = BuildingAccountTypeMapper.Instance.Map(item);
                //    res.AddReturnedValue(await WebBuildingAccountType.SendAsync(web));
                //}
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingNoteBussines item)
            => await SendToServerAsync(new List<BuildingNoteBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.BuildingNotes.ResetAsync(Cache.ConnectionString);
    }
}
