using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPhoneBookRepository
    {
        Task<List<PhoneBookBussines>> GetAllAsync(string _connectionString, Guid parentGuid, bool status);
        Task<PhoneBookBussines> GetAsync(string _connectionString, Guid guid);
        Task<List<PhoneBookBussines>> GetAllAsync(string _connectionString);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PhoneBookBussines item, bool status, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid parentGuid, bool status, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveByParentAsync(Guid parentGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(PhoneBookBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<PhoneBookBussines> items, SqlTransaction tr);
    }
}
