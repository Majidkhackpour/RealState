using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingConditionPersistenceRepository : GenericRepository<BuildingConditionBussines, BuildingCondition>, IBuildingConditionRepository
    {
        private ModelContext db;

        public BuildingConditionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
