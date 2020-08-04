using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityCache.Bussines;
using PacketParser.Interfaces;

namespace EntityCache.Core
{
    public interface IAdvertiseLogRepository : IRepository<AdvertiseLogBussines>
    {
        Task<AdvertiseLogBussines> GetAsync(string url);

        Task<List<AdvertiseLogBussines>> GetAllSpecialAsync(Expression<Func<IAdvertiseLog, bool>> @where = null,
            Func<IQueryable<IAdvertiseLog>, IOrderedQueryable<IAdvertiseLog>> @orderby = null, string includes = "",
            int takeCount = -1);
    }
}
