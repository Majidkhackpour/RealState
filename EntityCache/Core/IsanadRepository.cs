using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IsanadRepository
    {
        Task<List<SanadBussines>> GetAllAsync(string _connectionString);
        Task<SanadBussines> GetAsync(string _connectionString, long number);
        Task<long> NextNumberAsync(string _connectionString);
        Task<SanadBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(SanadBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<bool> CheckCodeAsync(string _connectionString, Guid guid, long code);
    }
}
