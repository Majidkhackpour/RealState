using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingRequestRegionRepository : IRepository<BuildingRequestRegionBussines>
    {
        Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid, bool status);
    }
}
