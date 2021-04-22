using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRelatedOptionsRepository
    {
        Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(string _connectionString, Guid parentGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRelatedOptionsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingRelatedOptionsBussines> items, SqlTransaction tr);
    }
}
