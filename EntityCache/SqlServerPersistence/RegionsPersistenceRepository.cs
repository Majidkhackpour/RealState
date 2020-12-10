using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class RegionsPersistenceRepository : GenericRepository<RegionsBussines, Regions>, IRegionsRepository
    {
        private ModelContext db;
        private string _connectionString;
        public RegionsPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<RegionsBussines>> GetAllAsync(Guid cityGuid)
        {
            try
            {
                var ctGuid = new SqlParameter("@cityGuid", cityGuid);
                var res = db.Database.SqlQuery<RegionsBussines>("sp_Regions_SelectAllByCityGuid @cityGuid", ctGuid);
                var a = res.ToList();
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

        public async Task<RegionsBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.Regions.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name);

                return Mappings.Default.Map<RegionsBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
