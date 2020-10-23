using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingTypeRepository : IRepository<BuildingTypeBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
        Task<BuildingTypeBussines> GetAsync(string name);
    }
}
