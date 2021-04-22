using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtRepository
    {
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtBussines item, SqlTransaction tr);
        Task<bool> CheckCodeAsync(string _connectionString, Guid guid, long code);
        Task<long> NextNumberAsync(string _connectionString);
        Task<PardakhtBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<PardakhtBussines>> GetAllAsync(string _connectionString);
    }
}
