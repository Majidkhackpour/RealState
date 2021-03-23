using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface IPardakhtCheckShakhsiRepository : IRepository<PardakhtCheckShakhsiBussines>
    {
        Task<List<PardakhtCheckShakhsiBussines>> GetAllAsync(Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid);
        Task<List<PardakhtCheckViewModel>> GetAllViewModelAsync();
    }
}
