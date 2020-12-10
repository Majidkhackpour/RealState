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
    public class BuildingRelatedOptionsPersistenceRepository : GenericRepository<BuildingRelatedOptionsBussines, BuildingRelatedOptions>, IBuildingRelatedOptionsRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingRelatedOptionsPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        
        public async Task<List<BuildingRelatedOptionsBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.BuildingRelatedOptions.AsNoTracking()
                    .Where(q => q.BuildinGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<BuildingRelatedOptionsBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
