using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBankSegestRepository 
    {
        Task<BankSegestBussines> GetAsync(string _connectionString, string bankName);
        Task<ReturnedSaveFuncInfo> SaveAsync(BankSegestBussines item, SqlTransaction tr);
        Task<List<BankSegestBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BankSegestBussines> items, SqlTransaction tr);
    }
}
