using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IAdvisorRepository
    {
        Task<List<AdvisorBussines>> GetAllAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(AdvisorBussines item, bool status, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(AdvisorBussines item, SqlTransaction tr);
        Task<AdvisorBussines> GetAsync(string connectionString, Guid guid);
    }
}
