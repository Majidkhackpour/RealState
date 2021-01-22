using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IContractRepository : IRepository<ContractBussines>
    {
        Task<List<ContractBussines>> GetAllAsyncBySp();
        Task<string> NextCodeAsync();
        Task<bool> CheckCodeAsync(string code, Guid guid);
        Task<int> DbCount(Guid userGuid);
    }
}
