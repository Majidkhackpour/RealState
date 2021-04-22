using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdvTokensRepository 
    {
        Task<AdvTokenBussines> GetTokenAsync(string _connectionString, long number, AdvertiseType type);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(AdvTokenBussines item, SqlTransaction tr);
    }
}
