using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingOptionRepository : IRepository<BuildingOptionsBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
        Task<BuildingOptionsBussines> GetAsync(string name);
    }
}
