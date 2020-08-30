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
    public class ContractFinancePersisteceRepository : GenericRepository<ContractFinanceBussines, ContractFinance>, IContractFinanceRepository
    {
        private ModelContext db;
        public ContractFinancePersisteceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }
        public async Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.ContractFinance.AsNoTracking()
                    .FirstOrDefault(q => q.ConGuid == parentGuid && q.Status == status);

                return Mappings.Default.Map<ContractFinanceBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
