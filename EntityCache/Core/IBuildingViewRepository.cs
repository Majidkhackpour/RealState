using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingViewRepository : IRepository<BuildingViewBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
