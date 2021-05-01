using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IFloorCoverRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<FloorCoverBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<FloorCoverBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(FloorCoverBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<FloorCoverBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(FloorCoverBussines item, bool status, SqlTransaction tr);
    }
}
