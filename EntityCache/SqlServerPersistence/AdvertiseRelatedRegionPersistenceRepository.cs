using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Interfaces;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseRelatedRegionPersistenceRepository : GenericRepository<AdvertiseRelatedRegionBussines, AdvertiseRelatedRegion>, IAdvertiseRelatedRegionRepository
    {
        private ModelContext db;

        public AdvertiseRelatedRegionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
