using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class KitchenServicePersistenceRepository : GenericRepository<KitchenServiceBussines, KitchenService>, IKitchenServiceRepository
    {
        private ModelContext db;

        public KitchenServicePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
