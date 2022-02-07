﻿using EntityCache.Bussines;
using Services;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.Core
{
    public interface IBuildingReviewRepository
    {
        Task<BuildingReviewBussines> GetAsync(string connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(BuildingReviewBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
    }
}
