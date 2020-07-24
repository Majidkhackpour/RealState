using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IRentalAuthorityRepository : IRepository<RentalAuthorityBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
    }
}
