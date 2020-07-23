﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using PacketParser.Services;
using Persistence.Entities;
using Persistence.Model;

namespace EntityCache.SqlServerPersistence
{
    public class DocumentTypePersistenceRepository : GenericRepository<DocumentTypeBussines, DocumentType>, IDocumentTypeRepository
    {
        private ModelContext db;

        public DocumentTypePersistenceRepository(ModelContext _db) : base(_db)
        {
            db = _db;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.DocumentType.AsNoTracking()
                    .Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
    }
}