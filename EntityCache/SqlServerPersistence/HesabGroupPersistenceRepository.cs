using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class HesabGroupPersistenceRepository : GenericRepository<HesabGroupBussines, HesabGroup>, IHesabGroupRepository
    {
        private ModelContext db;
        private string _connectionString;
        public HesabGroupPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
