using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPeoplesBankAccountRepository : IRepository<PeoplesBankAccountBussines>
    {
        Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid,bool status);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid parentGuid);
    }
}
