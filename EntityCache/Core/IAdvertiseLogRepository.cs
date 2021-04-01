using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IAdvertiseLogRepository : IRepository<AdvertiseLogBussines>
    {
        Task<AdvertiseLogBussines> GetAsync(string url);
    }
}
