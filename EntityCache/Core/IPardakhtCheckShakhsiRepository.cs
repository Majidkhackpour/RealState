using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtCheckShakhsiRepository
    {
        Task<PardakhtCheckShakhsiBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<PardakhtCheckShakhsiBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<List<PardakhtCheckViewModel>> GetAllViewModelAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PardakhtCheckShakhsiBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtCheckShakhsiBussines item, SqlTransaction tr);
    }
}
