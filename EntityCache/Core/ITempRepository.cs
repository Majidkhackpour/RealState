using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ITempRepository
    {
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<List<TempBussines>> GetAllAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(TempBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveOnModifiedAsync(DateTime date, string connectionString);
        Task UpdateEntityAsync(EnTemp type, Guid entityGuid, ServerStatus st, DateTime deliveryDate, string connectionString);
    }
}
