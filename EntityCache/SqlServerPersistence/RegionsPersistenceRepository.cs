﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class RegionsPersistenceRepository : GenericRepository<RegionsBussines, Regions>, IRegionsRepository
    {
        private ModelContext db;

        public RegionsPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<RegionsBussines>> GetAllAsync(Guid cityGuid)
        {
            try
            {
                var acc = db.Regions.AsNoTracking()
                    .Where(q => q.CityGuid == cityGuid)
                    .ToList();
                return Mappings.Default.Map<List<RegionsBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
