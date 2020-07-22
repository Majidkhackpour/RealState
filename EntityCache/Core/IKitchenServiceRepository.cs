using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IKitchenServiceRepository : IRepository<KitchenServiceBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
