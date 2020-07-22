using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IFloorCoverRepository : IRepository<FloorCoverBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
