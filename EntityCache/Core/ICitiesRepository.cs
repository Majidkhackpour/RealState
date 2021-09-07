using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ICitiesRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, Guid stateGuid, string name, Guid guid);
        Task<List<CitiesBussines>> GetAllAsync(string _connectionString, Guid stateGuid, CancellationToken token);
        Task<List<CitiesBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<CitiesBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(CitiesBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<CitiesBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(CitiesBussines item, bool status, SqlTransaction tr);
        Task<CitiesBussines> GetAsync(string _connectionString, string name);
    }
}
