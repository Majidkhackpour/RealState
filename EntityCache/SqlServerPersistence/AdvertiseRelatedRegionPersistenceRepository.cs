using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
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

        public async Task<AdvertiseRelatedRegionBussines> GetByRegionGuidAsync(Guid regionGuid)
        {
            try
            {
                var acc = db.AdvertiseRelatedRegion.AsNoTracking()
                    .FirstOrDefault(q => q.LocalRegionGuid == regionGuid && q.Status);

                return Mappings.Default.Map<AdvertiseRelatedRegionBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
