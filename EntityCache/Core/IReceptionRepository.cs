using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IReceptionRepository : IRepository<ReceptionBussines>
    {
        Task<long> NextNumberAsync();
        Task<bool> CheckCodeAsync(Guid guid, long code);
    }
}
