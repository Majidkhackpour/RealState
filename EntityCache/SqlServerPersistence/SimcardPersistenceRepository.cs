using System;
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
    public class SimcardPersistenceRepository : GenericRepository<SimcardBussines, Simcard>, ISimcardRepository
    {
        private ModelContext db;
        public SimcardPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<SimcardBussines> GetAsync(long number)
        {
            try
            {
                var acc = db.Simcard.AsNoTracking()
                    .FirstOrDefault(q => q.Number == number);

                return Mappings.Default.Map<SimcardBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<bool> CheckNumberAsync(long number, Guid guid)
        {
            try
            {
                var acc = db.Simcard.AsNoTracking()
                    .Where(q => q.Number == number && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}
