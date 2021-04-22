using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionNaqdRepository
    {
        Task<List<ReceptionNaqdBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<ReceptionNaqdBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionNaqdBussines item, SqlTransaction tr);
    }
}
