using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class PeopleBankAccountPersistenceRepository : GenericRepository<PeoplesBankAccountBussines, PeopleBankAccount>, IPeoplesBankAccountRepository
    {
        private ModelContext db;
        public PeopleBankAccountPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
