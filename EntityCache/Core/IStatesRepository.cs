using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IStatesRepository
    {
        Task<StatesBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<StatesBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(StatesBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<StatesBussines> items, SqlTransaction tr);
    }
}
