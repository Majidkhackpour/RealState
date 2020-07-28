using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IUsersRepository : IRepository<UserBussines>
    {
        Task<bool> CheckUserNameAsync(Guid guid, string userName);
        Task<UserBussines> GetAsync(string userName);
    }
}
