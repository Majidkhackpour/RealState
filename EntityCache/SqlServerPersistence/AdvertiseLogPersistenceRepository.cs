using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Interfaces;
using PacketParser.Services;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseLogPersistenceRepository : GenericRepository<AdvertiseLogBussines, AdvertiseLog>, IAdvertiseLogRepository
    {
        private ModelContext db;
        public AdvertiseLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<AdvertiseLogBussines> GetAsync(string url)
        {
            try
            {
                var acc = db.AdvertiseLog.AsNoTracking()
                    .FirstOrDefault(q => q.URL == url);

                return Mappings.Default.Map<AdvertiseLogBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<AdvertiseLogBussines>> GetAllSpecialAsync(Expression<Func<IAdvertiseLog, bool>> @where = null, Func<IQueryable<IAdvertiseLog>, IOrderedQueryable<IAdvertiseLog>> @orderby = null, string includes = "", int takeCount = -1)
        {
            try
            {
                IQueryable<IAdvertiseLog> query = db.AdvertiseLog;
                if (where != null) query = query.Where(@where);
                var res = query.ToList();
                return Mappings.Default.Map<List<AdvertiseLogBussines>>(res);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
