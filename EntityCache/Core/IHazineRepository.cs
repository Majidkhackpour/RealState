using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IHazineRepository : IRepository<HazineBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
