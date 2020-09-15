using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class NotePersistenceRepository : GenericRepository<NoteBussines, Note>, INoteRepository
    {
        private ModelContext db;
        public NotePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
