using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISmsLogRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(SmsLogBussines item, SqlTransaction tr);
        Task<List<SmsLogBussines>> GetAllAsync(string _connectionString);
        Task<SmsLogBussines> GetAsync(string _connectionString, Guid guid);
        Task<SmsLogBussines> GetAsync(string _connectionString, long messageId);
    }
}
