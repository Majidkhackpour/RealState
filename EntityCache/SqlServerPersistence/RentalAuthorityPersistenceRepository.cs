using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class RentalAuthorityPersistenceRepository : GenericRepository<RentalAuthorityBussines, RentalAuthority>, IRentalAuthorityRepository
    {
        private ModelContext db;

        public RentalAuthorityPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
