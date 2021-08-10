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
    public class TempBussines : ITemp
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public EnTemp Type { get; set; }
        public Guid ObjectGuid { get; set; }


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

                res.AddReturnedValue(await UnitOfWork.Temp.SaveAsync(this, tr));
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
        public static async Task<List<TempBussines>> GetAllAsync() => await UnitOfWork.Temp.GetAllAsync(Cache.ConnectionString);
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

                res.AddReturnedValue(await UnitOfWork.Temp.RemoveAsync(Guid, tr));
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
        public static async Task UpdateEntityAsync(EnTemp type, Guid entityGuid, ServerStatus st, DateTime deliveryDate)
        {
            try
            {
                if (st == ServerStatus.DeliveryError)
                {
                    var tmp = new TempBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Type = type,
                        ObjectGuid = entityGuid
                    };
                    await tmp.SaveAsync();
                    return;
                }
                await UnitOfWork.Temp.UpdateEntityAsync(type, entityGuid, st, deliveryDate, Cache.ConnectionString);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }

        public static async Task<ReturnedSaveFuncInfo> SaveOnModifiedAsync(DateTime date) =>
            await UnitOfWork.Temp.SaveOnModifiedAsync(date, Cache.ConnectionString);
    }
}
