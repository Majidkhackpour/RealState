using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdvertiseRelatedRegionRepository
    {
        Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseRelatedRegionBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<AdvertiseRelatedRegionBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(IEnumerable<Guid> items, SqlTransaction tr);
        Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(string connectionString, Guid regionGuid);
        Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string connectionString);
    }
}
