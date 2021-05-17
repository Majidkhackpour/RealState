using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;
using Services;

namespace EntityCache.Core
{
    public interface ISanadDetailRepository
    {
        Task<ReturnedSaveFuncInfo> SaveAsync(SanadDetailBussines item, SqlTransaction tr);
        Task<List<SanadDetailBussines>> GetAllAsync(string _connectionString, Guid masterGuid);
        Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr);
        Task<List<GardeshBussines>> GetAllGardeshAsync(string _connectionString, Guid tafsilGuid);
        Task<List<GardeshBussines>> GetAllRooznameAsync(string _connectionString, DateTime d1, DateTime d2, CancellationToken token);
        Task<List<TarazAzmayeshiViewModel>> GetAllTarazAzmayeshiAsync(string _connectionString, CancellationToken token);
        Task<List<TarazHesabViewModel>> GetAllTarazHesabAsync(string _connectionString, DateTime d1, DateTime d2, long code1, long code2, CancellationToken token);
        Task<SanadDetailBussines> GetAsync(string _connectionString, Guid guid);
        Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<SanadDetailBussines> items, SqlTransaction tr);
    }
}
