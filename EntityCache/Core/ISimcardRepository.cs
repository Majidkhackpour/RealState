using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISimcardRepository
    {
        Task<SimcardBussines> GetAsync(string _connectionString, long number);
        Task<SimcardBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<SimcardBussines>> GetAllAsync(string _connectionString);
        Task<bool> CheckNumberAsync(string _connectionString, long number, Guid guid);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(SimcardBussines item, bool status, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(SimcardBussines item, SqlTransaction tr);
    }
}
