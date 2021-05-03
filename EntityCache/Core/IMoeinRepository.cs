using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IMoeinRepository
    {
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<MoeinBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> UpdateAccountAsync(Guid guid, decimal price, SqlTransaction tr);
        Task<MoeinBussines> GetAsync(string _connectionString, string code);
        Task<ReturnedSaveFuncInfo> SaveAsync(MoeinBussines item, SqlTransaction tr);
        Task<List<MoeinBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<MoeinBussines> GetAsync(string _connectionString, Guid guid);
    }
}
