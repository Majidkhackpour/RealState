using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class MoeinPersistenceRepository : GenericRepository<MoeinBussines, Moein>, IMoeinRepository
    {
        private ModelContext db;
        private string _connectionString;
        public MoeinPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
