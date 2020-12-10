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
        private string _connectionString;
        public BuildingRequestPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
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
