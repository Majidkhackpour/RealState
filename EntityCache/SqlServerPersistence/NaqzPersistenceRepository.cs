using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class NaqzPersistenceRepository : GenericRepository<NaqzBussines, Naqz>, INaqzRepository
    {
        private ModelContext db;
        private string _connectionString;
        public NaqzPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
