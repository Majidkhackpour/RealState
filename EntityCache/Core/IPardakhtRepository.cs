using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPardakhtRepository : IRepository<PardakhtBussines>
    {
        Task<List<PardakhtBussines>> GetAllAsync(Guid payerGuid);
    }
}
