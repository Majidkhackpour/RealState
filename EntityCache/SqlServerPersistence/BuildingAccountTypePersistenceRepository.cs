using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingAccountTypePersistenceRepository : GenericRepository<BuildingAccountTypeBussines, BuildingAccountType>, IBuildingAccountTypeRepository
    {
        private ModelContext db;

        public BuildingAccountTypePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
