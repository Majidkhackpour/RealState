using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ITempRepository
    {
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<List<TempBussines>> GetAllAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(TempBussines item, SqlTransaction tr);
    }
}
