using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdjectiveDescriptionRepository
    {
        Task<List<AdjectiveDescriptionBussines>> GetAllAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(AdjectiveDescriptionBussines item, SqlTransaction tr);
        Task<AdjectiveDescriptionBussines> GetAsync(string connectionString, Guid guid);
    }
}
