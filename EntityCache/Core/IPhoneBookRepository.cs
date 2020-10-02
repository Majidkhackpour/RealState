using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPhoneBookRepository : IRepository<PhoneBookBussines>
    {
        Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid,bool status);
        Task<List<PhoneBookBussines>> GetAllBySpAsync(Guid parentGuid, bool status);
    }
}
