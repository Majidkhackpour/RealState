using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IRentalAuthorityRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<RentalAuthorityBussines> GetAsync(string _connectionString, string name);
        Task<RentalAuthorityBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<RentalAuthorityBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(RentalAuthorityBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<RentalAuthorityBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(RentalAuthorityBussines item, bool status, SqlTransaction tr);
        Task<List<RentalAuthorityBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
