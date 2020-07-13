using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class NaqzPersistenceRepository : GenericRepository<NaqzBussines, Naqz>, INaqzRepository
    {
        private ModelContext db;

        public NaqzPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
