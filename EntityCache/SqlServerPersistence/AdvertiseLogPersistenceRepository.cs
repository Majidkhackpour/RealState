using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
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
    }
}
