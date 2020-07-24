using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingConditionRepository : IRepository<BuildingConditionBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
