using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ITafsilRepository : IRepository<TafsilBussines>
    {
        Task<string> NextCodeAsync(HesabType type);
        Task<bool> CheckCodeAsync(Guid guid, string code);
    }
}
