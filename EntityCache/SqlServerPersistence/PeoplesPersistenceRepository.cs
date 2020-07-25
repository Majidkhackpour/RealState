using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class PeoplesPersistenceRepository : GenericRepository<PeoplesBussines, Peoples>, IPeoplesRepository
    {
        ModelContext db;
        public PeoplesPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
