﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface IRegionsRepository
    {
        Task<List<RegionsBussines>> GetAllAsync(string _connectionString, Guid cityGuid, CancellationToken token);
        Task<List<RegionsBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<RegionsBussines> GetAsync(string _connectionString, string name);
        Task<RegionsBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(RegionsBussines item, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<RegionsBussines> items, SqlTransaction tr);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(RegionsBussines item, bool status, SqlTransaction tr);
        Task<List<RegionReportViewModel>> GetAllBuildingReportAsync(string connectionString, CancellationToken token);
        Task<List<RegionReportViewModel>> GetAllRequestReportAsync(string connectionString, CancellationToken token);
        Task<List<RegionsBussines>> GetAllNotSentAsync(string connectionString);
        Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status);
        Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString);
    }
}
