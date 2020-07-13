using System.Data.Entity;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class UsersPersistenceRepository : GenericRepository<UserBussines, Users>, IUsersRepository
    {
        private ModelContext _db;

        public UsersPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }
    }
}
