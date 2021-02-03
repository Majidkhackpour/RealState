using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IContractFinanceRepository : IRepository<ContractFinanceBussines>
    {
        Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status);
        Task<decimal> GetTotalCommitionAsync(DateTime d1, DateTime d2);
        Task<decimal> GetTotalTaxAsync(DateTime d1, DateTime d2);
    }
}
