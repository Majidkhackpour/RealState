using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class StatesPersistenceRepository : GenericRepository<StatesBussines, States>, IStatesRepository
    {
        private ModelContext db;
        private string _connectionString;
        public StatesPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
