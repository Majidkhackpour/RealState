using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ICalendarRepository
    {
        Task<ReturnedSaveFuncInfo> RemoveAllAsync(SqlTransaction tr);
        Task<List<CalendarBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<CalendarBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(CalendarBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<CalendarBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
    }
}
