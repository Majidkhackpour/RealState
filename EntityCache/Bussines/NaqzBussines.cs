using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class NaqzBussines : INaqz
    {
        public Guid Guid { get; set; }
        public string Message { get; set; }
        public int UseCount { get; set; }


        public static async Task<List<NaqzBussines>> GetAllAsync() => await UnitOfWork.Naqz.GetAllAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<NaqzBussines> list, SqlTransaction tr=null)
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

                res.AddReturnedValue(await UnitOfWork.Naqz.SaveRangeAsync(list, tr));
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
        public static async Task<string> SetNaqzAsync(SqlTransaction tr=null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            NaqzBussines one = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                var all = await GetAllAsync();
                all = all.OrderBy(q => q.UseCount).ToList();
                one = all.First();

                if (one.UseCount >= 32000) one.UseCount = 1;
                else one.UseCount += 1;

                res.AddReturnedValue(await UnitOfWork.Naqz.SaveAsync(one, tr));
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
            return res.HasError ? "" : one?.Message;
        }
    }
}
