using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingViewPersistenceRepository : GenericRepository<BuildingViewBussines, BuildingView>, IBuildingViewRepository
    {
        private ModelContext db;

        public BuildingViewPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
