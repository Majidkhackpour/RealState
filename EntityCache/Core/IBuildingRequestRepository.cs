using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRequestRepository
    {
        Task<List<BuildingRequestBussines>> GetAllAsync(string _connectionString, bool status, CancellationToken token);
        Task<int> DbCount(string _connectionString, Guid userGuid);
        Task<BuildingRequestBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingRequestBussines item, bool status, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRequestBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> DeleteAsync(string connectionString, DateTime date);
    }
}
