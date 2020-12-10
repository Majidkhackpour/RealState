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
    public class PeoplesPersistenceRepository : GenericRepository<PeoplesBussines, Peoples>, IPeoplesRepository
    {
        ModelContext db;
        private string _connectionString;
        public PeoplesPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.Peoples.AsNoTracking()
                    .Where(q => q.GroupGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<PeoplesBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }

        public async Task<string> NextCodeAsync()
        {
            try
            {
                var all = await GetAllAsync();
                if (all.Count <= 0) return "001001";
                var code = all.ToList()?.Max(q => long.Parse(q.Code)) ?? 0;
                code += 1;
                var new_code = code.ToString();
                if (code < 10)
                {
                    new_code = "00000" + code;
                    return new_code;
                }
                if (code >= 10 && code < 100)
                {
                    new_code = "0000" + code;
                    return new_code;
                }
                if (code >= 100 && code < 1000)
                {
                    new_code = "000" + code;
                    return new_code;
                }

                if (code >= 1000 && code < 10000)
                {
                    new_code = "00" + code;
                    return new_code;
                }
                if (code >= 10000 && code < 100000)
                {
                    new_code = "0" + code;
                    return new_code;
                }
                if (code >= 100000 && code < 1000000)
                {
                    new_code = code.ToString();
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "001001";
            }
        }

        public async Task<bool> CheckCodeAsync(string code, Guid guid)
        {
            try
            {
                var acc = db.Peoples.AsNoTracking()
                    .Where(q => q.Code == code && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }

        public async Task<bool> CheckNameAsync(string name)
        {
            try
            {
                var acc = db.Peoples.AsNoTracking()
                    .Where(q => q.Name == name.Trim())
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
