using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IFileInfoRepository : IRepository<FileInfoBussines>
    {
        Task<FileInfoBussines> GetAsync(string fileName);
    }
}
