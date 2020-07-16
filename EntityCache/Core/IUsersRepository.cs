using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IUsersRepository : IRepository<UserBussines>
    {
        Task<bool> CheckUserName(Guid guid, string userName);
    }
}
