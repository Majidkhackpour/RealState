using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingWindowRepository
    {
        Task<bool> CheckNameAsync(string connectionString, string name, Guid guid);
        Task<BuildingWindowBussines> GetAsync(string connectionString, Guid guid);
        Task<List<BuildingWindowBussines>> GetAllAsync(string connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingWindowBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingWindowBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingWindowBussines item, bool status, SqlTransaction tr);
        Task<List<BuildingWindowBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
