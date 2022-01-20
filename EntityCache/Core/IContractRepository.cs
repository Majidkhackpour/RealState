using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Bussines.ReportBussines;
using EntityCache.ViewModels;
using Services;
using Services.FilterObjects;

namespace EntityCache.Core
{
    public interface IContractRepository
    {
        Task<List<ContractBussines>> GetAllAsync(string _connectionString, CancellationToken token);
        Task<string> NextCodeAsync(string _connectionString);
        Task<bool> CheckCodeAsync(string _connectionString, string code, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveAsync(ContractBussines item, SqlTransaction tr);
        Task<int> DbCount(string _connectionString, Guid userGuid);
        Task<ContractBussines> GetAsync(string _connectionString, Guid guid);
        Task<int> DischargeDbCount(string _connectionString, DateTime d1, DateTime d2);
        Task<List<BuildingDischargeViewModel>> DischargeListAsync(string _connectionString, DateTime d1, DateTime d2);
        Task<decimal> GetTotalBazaryab(string _connectionString, DateTime d1, DateTime d2);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr);
        Task<decimal> GetTotalCommitionAsync(string _connectionString, DateTime d1, DateTime d2);
        Task<decimal> GetTotalTaxAsync(string _connectionString, DateTime d1, DateTime d2);
        Task<List<ContractReportBusiness>> GetAllReportAsync(string connectionString, ContractFilter filter);
    }
}
