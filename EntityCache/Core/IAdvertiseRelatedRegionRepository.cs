using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IAdvertiseRelatedRegionRepository : IRepository<AdvertiseRelatedRegionBussines>
    {
        Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, bool status);
        Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(Guid regionGuid);
    }
}
