using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPeopleGroupRepository
    {
        Task<PeopleGroupBussines> GetAsync(string _connectionString, string name);
        Task<int> ChildCountAsync(string _connectionString, Guid guid);
        Task<PeopleGroupBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<PeopleGroupBussines>> GetAllAsync(string _connectionString, Guid? parentGuid);
        Task<ReturnedSaveFuncInfo> SaveAsync(PeopleGroupBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PeopleGroupBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PeopleGroupBussines item, bool status, SqlTransaction tr);
        Task<bool> CheckNameAsync(string _connectionString, string name, Guid guid);
        Task<List<PeopleGroupBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
