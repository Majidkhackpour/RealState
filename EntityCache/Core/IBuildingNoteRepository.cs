using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingNoteRepository
    {
        Task<List<BuildingNoteBussines>> GetAllAsync(string connectionString, Guid parentGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingNoteBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingNoteBussines> items, SqlTransaction tr);
        Task<List<BuildingNoteBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
