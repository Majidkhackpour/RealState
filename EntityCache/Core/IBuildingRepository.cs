using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using Services;
using Services.FilterObjects;

namespace EntityCache.Core
{
    public interface IBuildingRepository
    {
        Task<List<BuildingBussines>> GetAllWithoutParentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeParentAsync(Guid guid, EnBuildingParent parent, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingBussines item, bool status, SqlTransaction tr);
        Task<string> NextCodeAsync(string _connectionString);
        Task<bool> CheckCodeAsync(string _connectionString, string code, Guid guid);
        Task<int> DbCount(string _connectionString, Guid userGuid, short type);
        Task<ReturnedSaveFuncInfo> FixImageAsync(string _connectionString);
        Task<BuildingBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SetArchiveAsync(string _connectionString, DateTime date);
        Task<bool> CheckDuplicateAsync(string connectionString, string divarTitle);
        Task<List<string>> GetAllCollingAsync(string connectionString);
        Task<List<string>> GetAllHittingAsync(string connectionString);
        Task<List<BuildingReportBussines>> SearchAsync(string connectionString, BuildingFilter filter);
        Task<int> CheckAsync(string connectionString, BuildingBussines bu);
        Task<List<BuildingBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
        Task<BuildingReportBussines> GetFromReportAsync(string connectionString, Guid guid);
    }
}
