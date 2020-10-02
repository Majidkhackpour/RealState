using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class SmsLogPersistenceRepository : GenericRepository<SmsLogBussines, SmsLog>, ISmsLogRepository
    {
        private ModelContext db;
        public SmsLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SmsLogBussines> GetAsync(long messageId)
        {
            try
            {
                var acc = db.SmsLog.AsNoTracking().FirstOrDefault(q => q.MessageId == messageId);
                var ret = Mappings.Default.Map<SmsLogBussines>(acc);
                return ret;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<SmsLogBussines>> GetAllBySpAsync()
        {
            try
            {
                var res = db.Database.SqlQuery<SmsLogBussines>("sp_SmsLog_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
