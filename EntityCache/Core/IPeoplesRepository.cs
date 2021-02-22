using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPeoplesRepository : IRepository<PeoplesBussines>
    {
        Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<List<PeoplesBussines>> GetAllBirthDayAsync(string dateSh);
    }
}
