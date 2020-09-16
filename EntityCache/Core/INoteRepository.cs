using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface INoteRepository : IRepository<NoteBussines>
    {
        Task<List<NoteBussines>> GetAllAsyncBySp();
    }
}
