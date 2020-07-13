using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class RegionsPersistenceRepository : GenericRepository<RegionsBussines, Regions>, IRegionsRepository
    {
        private ModelContext db;

        public RegionsPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
