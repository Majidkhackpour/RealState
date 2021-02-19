using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ICheckPageRepository : IRepository<CheckPageBussines>
    {
        Task<List<CheckPageBussines>> GetAllAsync(Guid checkGuid);
        Task<ReturnedSaveFuncInfo> RemoveAllAsync(Guid checkGuid);
    }
}
