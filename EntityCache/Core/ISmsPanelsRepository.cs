using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISmsPanelsRepository
    {
        Task<SmsPanelsBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<SmsPanelsBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(SmsPanelsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(SmsPanelsBussines item, bool status, SqlTransaction tr);
    }
}
