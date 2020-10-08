using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Interfaces;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class AdvertiseRelatedRegionPersistenceRepository : GenericRepository<AdvertiseRelatedRegionBussines, AdvertiseRelatedRegion>, IAdvertiseRelatedRegionRepository
    {
        private ModelContext db;

        public AdvertiseRelatedRegionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
        public async Task<List<AdvertiseRelatedRegionBussines>> GetAllAsync(string onlineRegion, bool status)
        {
            try
            {
                var acc = db.AdvertiseRelatedRegion.AsNoTracking()
                    .Where(q => q.OnlineRegionName == onlineRegion.Trim() && q.Status == status).ToList();

                return Mappings.Default.Map<List<AdvertiseRelatedRegionBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
