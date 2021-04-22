using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBankRepository
    {
        Task<List<BankBussines>> GetAllAsync(string _connectionString);
        Task<BankBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BankBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BankBussines item, bool status, SqlTransaction tr);
    }
}
