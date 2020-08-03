using System;
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
    public class SimcardPersistenceRepository:GenericRepository<SimcardBussines,Simcard>,ISimcardRepository
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
    }
}
