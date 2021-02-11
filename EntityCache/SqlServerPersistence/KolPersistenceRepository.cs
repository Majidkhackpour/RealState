using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class KolPersistenceRepository : GenericRepository<KolBussines, Kol>, IKolRepository
    {
        private ModelContext db;
        private string _connectionString;
        public KolPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
