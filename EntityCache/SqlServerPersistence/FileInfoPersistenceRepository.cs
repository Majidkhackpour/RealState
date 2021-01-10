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
    public class FileInfoPersistenceRepository : GenericRepository<FileInfoBussines, FileInfo>, IFileInfoRepository
    {
        private string connectionString;
        private ModelContext db;
        public FileInfoPersistenceRepository(ModelContext _db, string _connectionString) : base(_db, _connectionString)
        {
            db = _db;
            connectionString = _connectionString;
        }

        public async Task<FileInfoBussines> GetAsync(string fileName)
        {
            try
            {
                var acc = db.FileInfo.AsNoTracking()
                    .FirstOrDefault(q => q.FileName == fileName);

                return Mappings.Default.Map<FileInfoBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
    }
}
