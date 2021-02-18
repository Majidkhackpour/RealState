using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class DasteCheckPersistenceRepository : GenericRepository<DasteCheckBussines, DasteCheck>, IDasteCheckRepository
    {
        private ModelContext db;

        private string _connectionString;
        public DasteCheckPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
