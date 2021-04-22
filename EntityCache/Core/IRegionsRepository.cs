using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IRegionsRepository
    {
        Task<List<RegionsBussines>> GetAllAsync(string _connectionString, Guid cityGuid);
        Task<List<RegionsBussines>> GetAllAsync(string _connectionString);
        Task<RegionsBussines> GetAsync(string _connectionString, string name);
        Task<RegionsBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(RegionsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<RegionsBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(RegionsBussines item, bool status, SqlTransaction tr);
    }
}
