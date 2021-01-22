using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;

namespace EntityCache.Core
{
    public interface IReceptionRepository : IRepository<ReceptionBussines>
    {
        Task<List<ReceptionBussines>> GetAllAsync(Guid receptioGuid);
        Task<int> DbCheckCount(string dateSh);
        Task<List<CheckViewModel>> CheckReportAsync(string dateSh);
    }
}
