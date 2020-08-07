using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class UsersPersistenceRepository : GenericRepository<UserBussines, Users>, IUsersRepository
    {
        private ModelContext _db;

        public UsersPersistenceRepository(ModelContext db) : base(db)
        {
            _db = db;
        }

        public async Task<bool> CheckUserNameAsync(Guid guid, string userName)
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

        public async Task<UserBussines> GetAsync(string userName)
        {
            try
            {
                var acc = _db.Users.AsNoTracking().FirstOrDefault(q => q.UserName == userName);
                return Mappings.Default.Map<UserBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<UserBussines> GetByEmailAsync(string email)
        {
            try
            {
                var acc = _db.Users.AsNoTracking().FirstOrDefault(q =>
                    !string.IsNullOrEmpty(q.Email) && q.Email == email.Trim() && q.Status);
                return Mappings.Default.Map<UserBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<UserBussines> GetByMobilAsync(string mobile)
        {
            try
            {
                var acc = _db.Users.AsNoTracking().FirstOrDefault(q =>
                    !string.IsNullOrEmpty(q.Mobile) && q.Mobile == mobile.Trim() && q.Status);
                return Mappings.Default.Map<UserBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<UserBussines>> GetAllAsync(EnSecurityQuestion question, string answer)
        {
            try
            {
                var acc = _db.Users.AsNoTracking().Where(q =>
                    !string.IsNullOrEmpty(q.AnswerQuestion) && q.SecurityQuestion == question &&
                    q.AnswerQuestion == answer && q.Status);
                return Mappings.Default.Map<List<UserBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
