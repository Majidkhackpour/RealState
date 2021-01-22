using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBuildingRequestRepository : IRepository<BuildingRequestBussines>
    {
        Task<List<BuildingRequestBussines>> GetAllAsyncBySp();
        Task<int> DbCount(Guid userGuid);
    }
}
