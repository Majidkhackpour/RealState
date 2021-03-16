﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface IReceptionCheckRepository : IRepository<ReceptionCheckBussines>
    {
        Task<List<ReceptionCheckBussines>> GetAllAsync(Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid);
        Task<List<ReceptionCheckViewModel>> GetAllViewModelAsync();
    }
}
