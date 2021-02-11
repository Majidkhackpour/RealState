﻿using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class TafsilPersistenceRepository : GenericRepository<TafsilBussines, Tafsil>, ITafsilRepository
    {
        private ModelContext db;
        private string _connectionString;
        public TafsilPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
    }
}
