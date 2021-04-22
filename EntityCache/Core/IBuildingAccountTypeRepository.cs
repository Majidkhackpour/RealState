using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingAccountTypeRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<List<BuildingAccountTypeBussines>> GetAllAsync(string _connectionString);
        Task<BuildingAccountTypeBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingAccountTypeBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingAccountTypeBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingAccountTypeBussines item, bool status, SqlTransaction tr);
    }
}
