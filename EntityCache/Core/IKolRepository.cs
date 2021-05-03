using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IKolRepository
    {
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<KolBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(KolBussines item, SqlTransaction tr);
        Task<List<KolBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<KolBussines> GetAsync(string _connectionString, Guid guid);
    }
}
