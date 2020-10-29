using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BackUpLogPersistenceRepository : GenericRepository<BackUpLogBussines, BackUpLog>, IBackUpLogRepository
    {
        private ModelContext db;
        public BackUpLogPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
