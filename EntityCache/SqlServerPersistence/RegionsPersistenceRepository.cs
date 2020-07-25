﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
                var ctGuid = new SqlParameter("@cityGuid", cityGuid);
                var res = db.Database.SqlQuery<RegionsBussines>("sp_Regions_SelectAllByCityGuid @cityGuid", ctGuid);
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<RegionsBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<RegionsBussines>("sp_Regions_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
