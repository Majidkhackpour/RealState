using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPeoplesRepository
    {
        Task<List<PeoplesBussines>> GetAllAsync(string _connectionString, Guid parentGuid, bool status);
        Task<List<PeoplesBussines>> GetAllAsync(string _connectionString);
        Task<PeoplesBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(PeoplesBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PeoplesBussines item, bool status, SqlTransaction tr);
        Task<List<PeoplesBussines>> GetAllBirthDayAsync(string _connectionString, string dateSh);
    }
}
