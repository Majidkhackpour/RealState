using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class FileInfoPersistenceRepository : GenericRepository<FileInfoBussines, FileInfo>, IFileInfoRepository
    {
        private string connectionString;
        private ModelContext db;
        public FileInfoPersistenceRepository(ModelContext _db, string _connectionString) : base(_db, _connectionString)
        {
            db = _db;
            connectionString = _connectionString;
        }
    }
}
