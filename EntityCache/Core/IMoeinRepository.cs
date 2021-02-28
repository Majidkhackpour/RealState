using System;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IMoeinRepository : IRepository<MoeinBussines>
    {
        Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price);
        Task<MoeinBussines> GetAsync(string code);
    }
}
