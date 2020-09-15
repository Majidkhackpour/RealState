using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IUserLogRepository : IRepository<UserLogBussines>
    {
        Task<List<UserLogBussines>> GetAllAsync(Guid userGuid, DateTime d1, DateTime d2);
    }
}
