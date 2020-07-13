using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class CitiesPersistenceRepository : GenericRepository<CitiesBussines, Cities>, ICitiesRepository
    {
        private ModelContext db;

        public CitiesPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
