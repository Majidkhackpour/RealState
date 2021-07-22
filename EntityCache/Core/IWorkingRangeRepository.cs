using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IWorkingRangeRepository
    {
        Task<List<WorkingRangeBussines>> GetAllAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> RemoveAllAsync(SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(WorkingRangeBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<WorkingRangeBussines> items, SqlTransaction tr);
        Task<WorkingRangeBussines> GetAsync(string connectionString, Guid guid);
    }
}
