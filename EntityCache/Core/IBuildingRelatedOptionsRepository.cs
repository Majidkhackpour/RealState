using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingRelatedOptionsRepository : IRepository<BuildingRelatedOptionsBussines>
    {
        Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid, bool status);
    }
}
