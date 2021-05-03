using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IDasteCheckRepository
    {
        Task<DasteCheckBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<DasteCheckBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(DasteCheckBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(DasteCheckBussines item, bool status, SqlTransaction tr);
    }
}
