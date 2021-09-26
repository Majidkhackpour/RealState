using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRelatedNumberRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRelatedNumberBussines item, SqlTransaction tr);
        Task<BuildingRelatedNumberBussines> GetAsync(string connectionString, Guid buildingGuid);
    }
}
