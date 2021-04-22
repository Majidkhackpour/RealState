using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionHavaleRepository
    {
        Task<List<ReceptionHavaleBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<ReceptionHavaleBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionHavaleBussines item, SqlTransaction tr);
    }
}
