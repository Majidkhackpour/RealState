using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingConditionRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<List<BuildingConditionBussines>> GetAllAsync(string _connectionString);
        Task<BuildingConditionBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingConditionBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingConditionBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingConditionBussines item, bool status, SqlTransaction tr);
    }
}
