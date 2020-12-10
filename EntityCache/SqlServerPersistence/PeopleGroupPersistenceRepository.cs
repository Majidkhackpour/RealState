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
    public class PeopleGroupPersistenceRepository : GenericRepository<PeopleGroupBussines, PeopleGroup>, IPeopleGroupRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PeopleGroupPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.PeopleGroup.AsNoTracking()
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

        public async Task<PeopleGroupBussines> GetAsync(string name)
        {
            try
            {
                var acc = db.PeopleGroup.AsNoTracking()
                    .FirstOrDefault(q => q.Name == name.Trim());

                return Mappings.Default.Map<PeopleGroupBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<int> ChildCountAsync(Guid guid)
        {
            try
            {
                var acc = db.PeopleGroup.AsNoTracking().Count(q => q.ParentGuid == guid && q.Status);
                return acc;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return 0;
            }
        }
    }
}
