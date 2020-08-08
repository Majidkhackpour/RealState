using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingGalleryRepository : IRepository<BuildingGalleryBussines>
    {
        Task<List<BuildingGalleryBussines>> GetAllAsync(Guid parentGuid, bool status);
    }
}
