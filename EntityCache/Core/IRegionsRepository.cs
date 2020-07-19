using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IRegionsRepository : IRepository<RegionsBussines>
    {
        Task<List<RegionsBussines>> GetAllAsync(Guid cityGuid);
    }
}
