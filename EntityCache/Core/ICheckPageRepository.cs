using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ICheckPageRepository
    {
        Task<List<CheckPageBussines>> GetAllAsync(string _connectionString, Guid checkGuid);
        Task<CheckPageBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(CheckPageBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAllAsync(Guid checkGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<CheckPageBussines> items, SqlTransaction tr);
    }
}
