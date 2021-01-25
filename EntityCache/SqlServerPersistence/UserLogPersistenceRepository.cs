using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class UserLogPersistenceRepository : GenericRepository<UserLogBussines, UserLog>, IUserLogRepository
    {
        private ModelContext db;
        private string _connectionString;
        public UserLogPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<UserLogBussines>> GetAllAsync(Guid userGuid, DateTime d1, DateTime d2)
        {
            try
            {
                var ctGuid = new SqlParameter("@userGuid", userGuid);
                var date1 = new SqlParameter("@date1", d1);
                var date2 = new SqlParameter("@date2", d2);
                var res = db.Database.SqlQuery<UserLogBussines>(
                    "sp_UserLog_SelectAll_ByUser_And_Date @userGuid,@date1,@date2", ctGuid, date1, date2);
                var a = res.ToList();
                return a;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(UserLogBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_UserLog_Insert", cn) {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                    cmd.Parameters.AddWithValue("@date", item.Date);
                    cmd.Parameters.AddWithValue("@action", (short) item.Action);
                    cmd.Parameters.AddWithValue("@part", (short) item.Part);
                    cmd.Parameters.AddWithValue("@desc", item.Description);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
