using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPeoplesRepository : IRepository<PeoplesBussines>
    {
        Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<string> NextCodeAsync();
        Task<bool> CheckCodeAsync(string code, Guid guid);
    }
}
