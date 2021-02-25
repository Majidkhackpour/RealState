using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface ISanadDetailRepository : IRepository<SanadDetailBussines>
    {
        Task<List<SanadDetailBussines>> GetAllAsync(Guid masterGuid);
    }
}
