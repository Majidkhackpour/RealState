using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionRepository
    {
        Task<List<ReceptionBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReceptionBussines> GetAsync(string _connectionString, Guid guid);
        Task<long> NextNumberAsync(string _connectionString);
        Task<bool> CheckCodeAsync(string _connectionString, Guid guid, long code);
        Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
    }
}
