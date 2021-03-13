using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPardakhtRepository : IRepository<PardakhtBussines>
    {
        Task<long> NextNumberAsync();
        Task<bool> CheckCodeAsync(Guid guid, long code);
    }
}
