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
        public PhoneBookPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
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
    }
}
