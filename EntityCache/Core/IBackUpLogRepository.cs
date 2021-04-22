using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBackUpLogRepository
    {
        Task<List<BackUpLogBussines>> GetAllAsync(string connectionString);
        Task<BackUpLogBussines> GetAsync(string connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BackUpLogBussines item, SqlTransaction tr);
    }
}
