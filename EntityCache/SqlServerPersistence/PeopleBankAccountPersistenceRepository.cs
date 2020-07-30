using System;
using System.Collections.Generic;
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
    public class PeopleBankAccountPersistenceRepository : GenericRepository<PeoplesBankAccountBussines, PeopleBankAccount>, IPeoplesBankAccountRepository
    {
        private ModelContext db;
        public PeopleBankAccountPersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.PeopleBankAccount.AsNoTracking()
                    .Where(q => q.ParentGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<PeoplesBankAccountBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
