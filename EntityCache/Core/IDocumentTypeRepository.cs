using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IDocumentTypeRepository
    {
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<DocumentTypeBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<DocumentTypeBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<ReturnedSaveFuncInfo> SaveAsync(DocumentTypeBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<DocumentTypeBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(DocumentTypeBussines item, bool status, SqlTransaction tr);
    }
}
