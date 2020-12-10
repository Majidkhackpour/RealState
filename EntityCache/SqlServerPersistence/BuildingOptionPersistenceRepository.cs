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
    public class BuildingOptionPersistenceRepository : GenericRepository<BuildingOptionsBussines, BuildingOptions>, IBuildingOptionRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingOptionPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.BuildingOptions.AsNoTracking()
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

        public async Task<BuildingOptionsBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.BuildingOptions.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name);
                return Mappings.Default.Map<BuildingOptionsBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
