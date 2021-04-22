using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionCheckRepository
    {
        Task<List<ReceptionCheckBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReceptionCheckBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<List<ReceptionCheckViewModel>> GetAllViewModelAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<ReceptionCheckBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionCheckBussines item, SqlTransaction tr);
    }
}
