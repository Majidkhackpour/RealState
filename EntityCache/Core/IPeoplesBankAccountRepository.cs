using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPeoplesBankAccountRepository
    {
        Task<List<PeoplesBankAccountBussines>> GetAllAsync(string _connectionString, Guid parentGuid);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid parentGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PeoplesBankAccountBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(PeoplesBankAccountBussines item, SqlTransaction tr);
    }
}
