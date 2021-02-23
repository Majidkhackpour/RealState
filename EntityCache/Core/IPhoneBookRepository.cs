using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using Services;

namespace EntityCache.Core
{
    public interface IPhoneBookRepository : IRepository<PhoneBookBussines>
    {
        Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid, bool status);
        Task<ReturnedSaveFuncInfo> ChangeStatusAsync(Guid parentGuid, bool status, string tranName);
        Task<ReturnedSaveFuncInfo> RemoveAsync(Guid parentGuid);
    }
}
