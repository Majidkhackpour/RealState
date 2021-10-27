using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdvertiseLogRepository
    {
        Task<AdvertiseLogBussines> GetAsync(string connectionString, string url);
        Task<ReturnedSaveFuncInfo> SaveAsync(AdvertiseLogBussines item, SqlTransaction tr);
        Task<List<AdvertiseLogBussines>> GetAllAsync(string connectionString, DateTime? d1, DateTime? d2, long numer);
    }
}
