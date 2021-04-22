using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingTypeRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<BuildingTypeBussines> GetAsync(string _connectionString, string name);
        Task<BuildingTypeBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<BuildingTypeBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingTypeBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingTypeBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingTypeBussines item, bool status, SqlTransaction tr);
    }
}
