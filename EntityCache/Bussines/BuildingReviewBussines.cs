using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class BuildingReviewBussines : IBuildingReview
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Guid CustometGuid { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }

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

                res.AddReturnedValue(await UnitOfWork.BuildingReview.SaveAsync(this, tr));
                if (res.HasError) return res;

                //var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                //res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingType, Guid, "", tr));
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
                //if (!res.HasError && Cache.IsSendToServer)
                //    _ = Task.Run(() => SendToServerAsync(this));
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

                ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await UnitOfWork.BuildingReview.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                //var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                //res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingType, Guid, "", tr));
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
                //if (!res.HasError && Cache.IsSendToServer)
                //    _ = Task.Run(() => SendToServerAsync(this));
            }
            return res;
        }
    }
}
