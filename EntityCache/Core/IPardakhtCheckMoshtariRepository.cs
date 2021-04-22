using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtCheckMoshtariRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtCheckMoshtariBussines item, SqlTransaction tr);
        Task<List<PardakhtCheckMoshtariBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PardakhtCheckMoshtariBussines> items, SqlTransaction tr);
    }
}
