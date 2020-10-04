using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISerializedDataRepository : IRepository<SerializedDataBussines>
    {
        Task<SerializedDataBussines> GetAsync(string memberName);
    }
}
