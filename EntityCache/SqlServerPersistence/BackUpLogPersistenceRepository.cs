﻿using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class BackUpLogPersistenceRepository : GenericRepository<BackUpLogBussines, BackUpLog>, IBackUpLogRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BackUpLogPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
