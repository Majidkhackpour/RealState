using EntityCache.Assistence;
using Persistence;
using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class WorkingRangeBussines : IWorkingRange
    {
        public Guid Guid { get; set; }
        public Guid RegionGuid { get; set; }


        public static async Task<List<WorkingRangeBussines>> GetAllAsync() => await UnitOfWork.WorkingRange.GetAllAsync(Cache.ConnectionString);
        public static async Task<WorkingRangeBussines> GetAsync(Guid guid) => await UnitOfWork.WorkingRange.GetAsync(Cache.ConnectionString, guid);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<WorkingRangeBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.WorkingRange.RemoveAllAsync(tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.WorkingRange.SaveRangeAsync(list, tr));
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
    }
}
