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
    public class AdvTokensPersistenceRepository : GenericRepository<AdvTokenBussines, AdvToken>, IAdvTokensRepository
    {
        private ModelContext db;
        private string _connectionString;
        public AdvTokensPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<AdvTokenBussines> GetTokenAsync(long number, AdvertiseType type)
        {
            try
            {
                var acc = db.AdvTokens.AsNoTracking()
                    .FirstOrDefault(q => q.Number == number && q.Type == type);
                return Mappings.Default.Map<AdvTokenBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
