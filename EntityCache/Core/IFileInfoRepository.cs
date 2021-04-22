using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IFileInfoRepository
    {
        Task<FileInfoBussines> GetAsync(string connectionString, string fileName);
        Task<ReturnedSaveFuncInfo> SaveAsync(FileInfoBussines item, SqlTransaction tr);
    }
}
