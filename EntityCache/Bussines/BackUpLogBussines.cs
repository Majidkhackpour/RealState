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
    public class BackUpLogBussines : IBackUpLog
    {
        public Guid Guid { get; set; }
        public DateTime InsertedDate { get; set; }
        public string DateSh => Calendar.MiladiToShamsi(InsertedDate);
        public string Path { get; set; }
        public EnBackUpType Type { get; set; }
        public string TypeName => Type.GetDisplay();
        public EnBackUpStatus BackUpStatus { get; set; }
        public string StatusName => BackUpStatus.GetDisplay();
        public string StatusDesc { get; set; }
        public short Size { get; set; }

        public static async Task<BackUpLogBussines> GetAsync(Guid guid) => await UnitOfWork.BackUpLog.GetAsync(Cache.ConnectionString, guid);
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


                res.AddReturnedValue(await UnitOfWork.BackUpLog.SaveAsync(this, tr));
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
        public static async Task<List<BackUpLogBussines>> GetAllAsync() => await UnitOfWork.BackUpLog.GetAllAsync(Cache.ConnectionString);
    }
}
