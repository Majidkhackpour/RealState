using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class TempPersistenceRepository : GenericRepository<TempBussines, Temp>, ITempRepository
    {
        private ModelContext db;
        private string connectionString;
        public TempPersistenceRepository(ModelContext _db, string _connectionString) : base(_db, _connectionString)
        {
            db = _db;
            connectionString = _connectionString;
        }
    }
}
