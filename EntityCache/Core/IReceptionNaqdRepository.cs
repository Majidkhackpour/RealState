using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionNaqdRepository : IRepository<ReceptionNaqdBussines>
    {
        Task<List<ReceptionNaqdBussines>> GetAllAsync(Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid);
    }
}
