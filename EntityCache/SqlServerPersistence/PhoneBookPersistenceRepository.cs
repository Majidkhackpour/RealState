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
    public class PhoneBookPersistenceRepository : GenericRepository<PhoneBookBussines, PhoneBook>, IPhoneBookRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PhoneBookPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.PhoneBook.AsNoTracking()
                    .Where(q => q.ParentGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<PhoneBookBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<List<PhoneBookBussines>> GetAllBySpAsync(Guid parentGuid, bool status)
        {
            try
            {
                var res = db.Database.SqlQuery<PhoneBookBussines>("sp_PhoneBook_SelectAll");
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
