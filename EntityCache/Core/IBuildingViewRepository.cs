using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingViewRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<BuildingViewBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<BuildingViewBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingViewBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingViewBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingViewBussines item, bool status, SqlTransaction tr);
    }
}
