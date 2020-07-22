using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingAccountTypeRepository : IRepository<BuildingAccountTypeBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
