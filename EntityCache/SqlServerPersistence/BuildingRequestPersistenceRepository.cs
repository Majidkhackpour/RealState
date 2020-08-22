using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingRequestPersistenceRepository : GenericRepository<BuildingRequestBussines, BuildingRequest>, IBuildingRequestRepository
    {
        private ModelContext db;
        public BuildingRequestPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<BuildingRequestBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<BuildingRequestBussines>("sp_BuildingsReq_SelectAll");
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
