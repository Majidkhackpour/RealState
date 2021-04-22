using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtCheckAvalDoreRepository
    {
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<List<PardakhtCheckAvalDoreBussines>> GetAllAsync(string _connectionString);
        Task<PardakhtCheckAvalDoreBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtCheckAvalDoreBussines item, SqlTransaction tr);
    }
}
