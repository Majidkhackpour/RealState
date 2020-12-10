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
    public class SerializedDataPersistenceRepository : GenericRepository<SerializedDataBussines, SerializedData>, ISerializedDataRepository
    {
        private ModelContext db;
        private string _connectionString;
        public SerializedDataPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        public async Task<SerializedDataBussines> GetAsync(string memberName)
        {
            try
            {
                var acc = db.SerializedData.AsNoTracking().FirstOrDefault(q => q.Name == memberName);
                var ret = Mappings.Default.Map<SerializedDataBussines>(acc);
                return ret;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
