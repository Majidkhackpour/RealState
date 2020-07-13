using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class DocumentTypePersistenceRepository : GenericRepository<DocumentTypeBussines, DocumentType>, IDocumentTypeRepository
    {
        private ModelContext db;

        public DocumentTypePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
