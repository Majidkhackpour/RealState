using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;

namespace EntityCache.Core
{
    public interface IContractRepository : IRepository<ContractBussines>
    {
        Task<string> NextCodeAsync();
        Task<bool> CheckCodeAsync(string code, Guid guid);
        Task<int> DbCount(Guid userGuid);
        Task<int> DischargeDbCount(DateTime d1, DateTime d2);
        Task<List<BuildingDischargeViewModel>> DischargeListAsync(DateTime d1, DateTime d2);
        Task<decimal> GetTotalBazaryab(DateTime d1, DateTime d2);
        Task<decimal> GetTotalCommitionAsync(DateTime d1, DateTime d2);
        Task<decimal> GetTotalTaxAsync(DateTime d1, DateTime d2);
    }
}
