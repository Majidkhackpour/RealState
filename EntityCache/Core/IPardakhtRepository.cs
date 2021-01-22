using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.ViewModels;

namespace EntityCache.Core
{
    public interface IPardakhtRepository : IRepository<PardakhtBussines>
    {
        Task<List<PardakhtBussines>> GetAllAsync(Guid payerGuid);
        Task<int> DbCheckCount(string dateSh);
        Task<List<CheckViewModel>> CheckReportAsync(string dateSh);
    }
}
