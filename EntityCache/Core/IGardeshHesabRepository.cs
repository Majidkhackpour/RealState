using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IGardeshHesabRepository : IRepository<GardeshHesabBussines>
    {
        Task<int> GardeshCountAsync(Guid hesabGuid);
        Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid);
    }
}
