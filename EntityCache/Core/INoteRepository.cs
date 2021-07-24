using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface INoteRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(NoteBussines item, SqlTransaction tr);
        Task<NoteBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<NoteBussines>> GetAllAsync(string _connectionString);
        Task<List<NoteBussines>> GetAllTodayNotesAsync(string connectionString, DateTime d1, DateTime d2, Guid userGuid);
    }
}
