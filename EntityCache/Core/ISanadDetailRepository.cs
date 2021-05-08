using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISanadDetailRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(SanadDetailBussines item, SqlTransaction tr);
        Task<List<SanadDetailBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<List<GardeshBussines>> GetAllGardeshAsync(string _connectionString, Guid tafsilGuid);
        Task<SanadDetailBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<SanadDetailBussines> items, SqlTransaction tr);
    }
}
