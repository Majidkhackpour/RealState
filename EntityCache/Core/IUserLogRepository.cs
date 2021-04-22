using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IUserLogRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(UserLogBussines item, SqlTransaction tr);
        Task<List<UserLogBussines>> GetAllAsync(string _connectionString, Guid userGuid, DateTime d1, DateTime d2);
    }
}
