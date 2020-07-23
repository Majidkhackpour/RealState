using System;
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
    public class CitiesPersistenceRepository : GenericRepository<CitiesBussines, Cities>, ICitiesRepository
    {
        private ModelContext db;

        public CitiesPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckNameAsync(Guid stateGuid, string name, Guid guid)
        {
            try
            {
                var acc = db.Cities.AsNoTracking()
                    .Where(q => q.Name == name && q.StateGuid == stateGuid && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public async Task<List<CitiesBussines>> GetAllAsync(Guid stateGuid)
        {
            try
            {
                var acc = db.Cities.AsNoTracking()
                    .Where(q => q.StateGuid == stateGuid)
                    .ToList();
                return Mappings.Default.Map<List<CitiesBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<CitiesBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<CitiesBussines>("sp_Cities_SelectAll");
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
