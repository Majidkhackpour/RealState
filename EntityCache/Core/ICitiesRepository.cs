using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ICitiesRepository : IRepository<CitiesBussines>
    {
        Task<bool> CheckNameAsync(Guid stateGuid, string name, Guid guid);
        Task<List<CitiesBussines>> GetAllAsync(Guid stateGuid);
    }
}
