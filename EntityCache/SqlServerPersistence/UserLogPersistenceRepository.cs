using System;
using System.Collections.Generic;
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
        public UserLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
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
    }
}
