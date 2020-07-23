using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IDocumentTypeRepository : IRepository<DocumentTypeBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
