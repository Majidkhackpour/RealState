using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IGardeshHesabRepository : IRepository<GardeshHesabBussines>
    {
        Task<GardeshHesabBussines> GetAsync(Guid hesabGuid, Guid parentGuid, bool status);
        Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid);
        Task<List<GardeshHesabBussines>> GetAllAsync(Guid parentGuid, bool status);
    }
}
