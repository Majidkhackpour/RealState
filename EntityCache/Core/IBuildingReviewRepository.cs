using EntityCache.Bussines;
using Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines.ReportBussines;
using Services.FilterObjects;

namespace EntityCache.Core
{
    public interface IBuildingReviewRepository
    {
        Task<BuildingReviewBussines> GetAsync(string connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingReviewBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<List<BuildingReviewBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
        Task<List<BuildingReviewReportBussines>> GetAllReportAsync(string connectionString, BuildingReviewFilter filter);
    }
}
