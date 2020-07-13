using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingOptionPersistenceRepository : GenericRepository<BuildingOptionsBussines, BuildingOptions>, IBuildingOptionRepository
    {
        private ModelContext db;

        public BuildingOptionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
