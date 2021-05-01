using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingOptionRepository
    {
        Task<BuildingOptionsBussines> GetAsync(string _connectionString, string name);
        Task<BuildingOptionsBussines> GetAsync(string _connectionString, Guid guid);
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<List<BuildingOptionsBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingOptionsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingOptionsBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingOptionsBussines item, bool status, SqlTransaction tr);
    }
}
