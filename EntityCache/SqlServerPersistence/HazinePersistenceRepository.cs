﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class HazinePersistenceRepository : GenericRepository<HazineBussines, Hazine>, IHazineRepository
    {
        private ModelContext db;
        public HazinePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.Hazine.AsNoTracking()
                    .Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}