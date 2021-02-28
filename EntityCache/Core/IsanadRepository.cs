﻿using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IsanadRepository : IRepository<SanadBussines>
    {
        Task<SanadBussines> GetAsync(long number);
        Task<long> NextNumberAsync();
        Task<bool> CheckCodeAsync(Guid guid, long code);
    }
}
