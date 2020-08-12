using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingRepository : IRepository<BuildingBussines>
    {
        Task<List<BuildingBussines>> GetAllAsyncBySp();
        Task<string> NextCodeAsync();
        Task<bool> CheckCodeAsync(string code, Guid guid);
    }
}
