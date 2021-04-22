using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface ISerializedDataRepository
    {
        Task<SerializedDataBussines> GetAsync(string connectionString, string memberName);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(SerializedDataBussines item, SqlTransaction tr);
    }
}
