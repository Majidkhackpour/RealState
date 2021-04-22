using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface INaqzRepository
    {
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<NaqzBussines> items, SqlTransaction tr);
        Task<List<NaqzBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(NaqzBussines item, SqlTransaction tr);
    }
}
