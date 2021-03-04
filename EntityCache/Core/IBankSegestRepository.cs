using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IBankSegestRepository : IRepository<BankSegestBussines>
    {
        Task<BankSegestBussines> GetAsync(string bankName);
    }
}
