using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRelatedOptionsRepository : IRepository<BuildingRelatedOptionsBussines>
    {
        Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid masterGuid, bool status);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, string tranName);
    }
}
