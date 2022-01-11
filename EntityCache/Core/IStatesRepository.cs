using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IStatesRepository
    {
        Task<StatesBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<StatesBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(StatesBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<StatesBussines> items, SqlTransaction tr);
        Task<StatesBussines> GetAsync(string _connectionString, string name);
        Task<List<StatesBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
