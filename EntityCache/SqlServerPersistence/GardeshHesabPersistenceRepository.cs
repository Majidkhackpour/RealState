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
    public class GardeshHesabPersistenceRepository : GenericRepository<GardeshHesabBussines, GardeshHesab>, IGardeshHesabRepository
    {
        private ModelContext db;
        public GardeshHesabPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<int> GardeshCountAsync(Guid hesabGuid)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking().Count(q => q.PeopleGuid == hesabGuid && q.Status);
                return acc;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return 0;
            }
        }

        public async Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking()
                    .Where(q => q.PeopleGuid == hesabGuid).ToList();

                return Mappings.Default.Map<List<GardeshHesabBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
