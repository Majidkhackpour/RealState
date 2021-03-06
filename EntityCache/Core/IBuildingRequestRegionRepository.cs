﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IBuildingRequestRegionRepository
    {
        Task<List<BuildingRequestRegionBussines>> GetAllAsync(string _connectionString, Guid parentGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRequestRegionBussines item, SqlTransaction tr);
        Task<BuildingRequestRegionBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<BuildingRequestRegionBussines> items, SqlTransaction tr);
    }
}
