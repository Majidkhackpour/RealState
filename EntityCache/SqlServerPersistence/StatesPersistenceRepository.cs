using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class StatesPersistenceRepository : GenericRepository<StatesBussines, States>, IStatesRepository
    {
        private ModelContext db;

        public StatesPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
