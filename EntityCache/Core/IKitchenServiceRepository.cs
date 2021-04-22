using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IKitchenServiceRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<KitchenServiceBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<KitchenServiceBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(KitchenServiceBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<KitchenServiceBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(KitchenServiceBussines item, bool status, SqlTransaction tr);
    }
}
