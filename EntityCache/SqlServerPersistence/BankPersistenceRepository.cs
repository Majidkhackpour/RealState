using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BankPersistenceRepository : GenericRepository<BankBussines, Bank>, IBankRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BankPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
