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
    public class BuildingGalleryPersistenceRepository : GenericRepository<BuildingGalleryBussines, BuildingGallery>, IBuildingGalleryRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingGalleryPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<BuildingGalleryBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.BuildingGallery.AsNoTracking()
                    .Where(q => q.BuildingGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<BuildingGalleryBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
