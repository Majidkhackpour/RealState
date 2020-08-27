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
    public class BuildingRequestRegionPersistenceRepository : GenericRepository<BuildingRequestRegionBussines, BuildingRequestRegion>, IBuildingRequestRegionRepository
    {
        private ModelContext db;
        public BuildingRequestRegionPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<BuildingRequestRegionBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.BuildingRequestRegions.AsNoTracking()
                    .Where(q => q.RequestGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<BuildingRequestRegionBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
