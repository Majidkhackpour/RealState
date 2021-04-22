using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IUsersRepository
    {
        Task<bool> CheckUserNameAsync(string _connectionString, Guid guid, string userName);
        Task<UserBussines> GetAsync(string _connectionString, string userName);
        Task<UserBussines> GetByEmailAsync(string _connectionString, string email);
        Task<UserBussines> GetByMobilAsync(string _connectionString, string mobile);
        Task<List<UserBussines>> GetAllAsync(string _connectionString, EnSecurityQuestion question, string answer);
        Task<UserBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<UserBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> SaveAsync(UserBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(UserBussines item, bool status, SqlTransaction tr);
    }
}
