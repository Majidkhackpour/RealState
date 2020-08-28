using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IReceptionRepository : IRepository<ReceptionBussines>
    {
        Task<List<ReceptionBussines>> GetAllAsync(Guid receptioGuid);
    }
}
