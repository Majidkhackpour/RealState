using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
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

        public async Task<bool> CheckUserName(Guid guid, string userName)
        {
            try
            {
                var acc = _db.Users.AsNoTracking().Where(q => q.UserName == userName && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}
