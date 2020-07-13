using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class FloorCoverPersistenceRepository : GenericRepository<FloorCoverBussines, FloorCover>, IFloorCoverRepository
    {
        private ModelContext db;

        public FloorCoverPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
