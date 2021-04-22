using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(Date);
        public string Time => Date.ToShortTimeString();
        public EnLogAction Action { get; set; }
        public string ActionName => Action.GetDisplay();
        public EnLogPart Part { get; set; }
        public string PartName => Part.GetDisplay();
        public string Description { get; set; }



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

                res.AddReturnedValue(await UnitOfWork.UserLog.SaveAsync(this, tr));
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
        public ReturnedSaveFuncInfo Save(SqlTransaction tr = null) => AsyncContext.Run(() => SaveAsync(tr));
        public static async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid, DateTime d1, DateTime d2) =>
            await UnitOfWork.UserLog.GetAllAsync(Cache.ConnectionString, userGuid, d1, d2);
    }
}
