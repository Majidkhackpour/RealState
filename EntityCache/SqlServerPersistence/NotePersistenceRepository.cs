using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class NotePersistenceRepository : GenericRepository<NoteBussines, Note>, INoteRepository
    {
        private ModelContext db;
        public NotePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<List<NoteBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<NoteBussines>("sp_Note_SelectAll");
                var a = res.ToList();
                return a;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
