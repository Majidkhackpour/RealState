using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionCheckAvalDoreRepository
    {
        Task<List<ReceptionCheckAvalDoreBussines>> GetAllAsync(string _connectionString);
        Task<ReceptionCheckAvalDoreBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionCheckAvalDoreBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
    }
}
