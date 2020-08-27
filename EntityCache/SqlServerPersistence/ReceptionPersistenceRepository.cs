using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class ReceptionPersistenceRepository : GenericRepository<ReceptionBussines, Reception>, IReceptionRepository
    {
        private ModelContext db;
        public ReceptionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
