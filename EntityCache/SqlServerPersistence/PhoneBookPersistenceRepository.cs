using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class PhoneBookPersistenceRepository : GenericRepository<PhoneBookBussines, PhoneBook>, IPhoneBookRepository
    {
        private ModelContext db;
        public PhoneBookPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
