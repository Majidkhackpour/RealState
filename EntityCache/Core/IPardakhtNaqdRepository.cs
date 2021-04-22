using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtNaqdRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtNaqdBussines item, SqlTransaction tr);
        Task<List<PardakhtNaqdBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PardakhtNaqdBussines> items, SqlTransaction tr);
    }
}
