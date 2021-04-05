using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingGalleryRepository : IRepository<BuildingGalleryBussines>
    {
        Task<List<BuildingGalleryBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid masterGuid, bool status);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, string tranName);
    }
}
