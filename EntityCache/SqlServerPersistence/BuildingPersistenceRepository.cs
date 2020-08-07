using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingPersistenceRepository : GenericRepository<BuildingBussines, Building>, IBuildingRepository
    {
        private ModelContext db;
        public BuildingPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
