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
    public class RentalAuthorityPersistenceRepository : GenericRepository<RentalAuthorityBussines, RentalAuthority>, IRentalAuthorityRepository
    {
        private ModelContext db;
        private string _connectionString;
        public RentalAuthorityPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.RentalAuthority.AsNoTracking()
                    .Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public async Task<RentalAuthorityBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.RentalAuthority.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name);
                return Mappings.Default.Map<RentalAuthorityBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
