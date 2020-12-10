using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class SmsPanelsPersistenceRepository : GenericRepository<SmsPanelsBussines, SmsPanels>, ISmsPanelsRepository
    {
        private ModelContext db;
        private string _connectionString;
        public SmsPanelsPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
