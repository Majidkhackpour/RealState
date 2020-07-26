﻿using System;
using System.Threading.Tasks;
using EntityCache.Bussines;

namespace EntityCache.Core
{
    public interface IPeopleGroupRepository : IRepository<PeopleGroupBussines>
    {
        Task<bool> CheckNameAsync(string name, Guid guid);
        Task<PeopleGroupBussines> GetAsync(string name);
        Task<int> ChildCountAsync(Guid guid);
    }
}
