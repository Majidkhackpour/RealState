using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRepository
    {
        Task<List<BuildingBussines>> GetAllAsync(string _connectionString, CancellationToken token, bool isLoadDets);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingBussines item, bool status, SqlTransaction tr);
        Task<string> NextCodeAsync(string _connectionString);
        Task<bool> CheckCodeAsync(string _connectionString, string code, Guid guid);
        Task<int> DbCount(string _connectionString, Guid userGuid, short type);
        Task<ReturnedSaveFuncInfo> FixImageAsync(string _connectionString);
        Task<BuildingBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SetArchiveAsync(string _connectionString, DateTime date);
        Task<List<BuildingBussines>> GetAllHighPriorityAsync(string _connectionString, CancellationToken token);
        Task<bool> CheckDuplicateAsync(string connectionString, string divarTitle);
        Task<List<string>> GetAllCollingAsync(string connectionString);
        Task<List<string>> GetAllHittingAsync(string connectionString);
    }
}
