using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class SmsPanelsPersistenceRepository : GenericRepository<SmsPanelsBussines, SmsPanels>, ISmsPanelsRepository
    {
        private ModelContext db;
        public SmsPanelsPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
