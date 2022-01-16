using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISettingsRepository
    {
        Task<SettingsBussines> GetAsync(string _connectionString, string memberName);
        SettingsBussines Get(string _connectionString, string memberName);
        Task<ReturnedSaveFuncInfo> SaveAsync(SettingsBussines item, SqlTransaction tr);
        ReturnedSaveFuncInfo Save(SettingsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<List<SettingsBussines>> GetAllAsync(string _connectionString);
    }
}
