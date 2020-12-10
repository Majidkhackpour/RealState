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
        private string _connectionString;
        public GardeshHesabPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<GardeshHesabBussines> GetAsync(Guid hesabGuid, Guid parentGuid,bool status)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking().FirstOrDefault(q =>
                    q.ParentGuid == parentGuid && q.PeopleGuid == hesabGuid && q.Status == status);

                return Mappings.Default.Map<GardeshHesabBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
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

        public async Task<List<GardeshHesabBussines>> GetAllBySpAsync()
        {
            try
            {
                var res = db.Database.SqlQuery<GardeshHesabBussines>("sp_Gardesh_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }

        public async Task<List<GardeshHesabBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking()
                    .Where(q => q.ParentGuid == parentGuid && q.Status == status).ToList();

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
