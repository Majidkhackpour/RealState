using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IUsersRepository : IRepository<UserBussines>
    {
        Task<bool> CheckUserNameAsync(Guid guid, string userName);
        Task<UserBussines> GetAsync(string userName);
        Task<UserBussines> GetByEmailAsync(string email);
        Task<UserBussines> GetByMobilAsync(string mobile);
        Task<List<UserBussines>> GetAllAsync(EnSecurityQuestion question, string answer);
    }
}
