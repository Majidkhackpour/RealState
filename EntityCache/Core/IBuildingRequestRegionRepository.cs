using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRequestRegionRepository : IRepository<BuildingRequestRegionBussines>
    {
        Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid masterGuid, bool status, string tranName);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, string tranName);
    }
}
