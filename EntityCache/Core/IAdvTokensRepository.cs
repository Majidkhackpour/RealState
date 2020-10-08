using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdvTokensRepository : IRepository<AdvTokenBussines>
    {
        Task<AdvTokenBussines> GetTokenAsync(long number, AdvertiseType type);
    }
}
