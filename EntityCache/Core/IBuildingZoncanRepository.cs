using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingZoncanRepository
    {
        Task<BuildingZoncanBussines> GetAsync(string connectionString, Guid guid);
        Task<List<BuildingZoncanBussines>> GetAllAsync(string connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingZoncanBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingZoncanBussines item, bool status, SqlTransaction tr);
        Task<List<BuildingZoncanBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
        Task<bool> CheckNameAsync(string connectionString, string name, Guid guid);
    }
}
