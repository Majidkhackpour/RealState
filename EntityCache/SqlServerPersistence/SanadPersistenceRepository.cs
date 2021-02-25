using System;
using System.Data.SqlClient;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class SanadPersistenceRepository : GenericRepository<SanadBussines, Sanad>, IsanadRepository
    {
        private ModelContext db;
        private string _connectionString;
        public SanadPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        private SanadBussines LoadData(SqlDataReader dr)
        {
            var item = new SanadBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.DateM = (DateTime)dr["DateM"];
                item.Description = dr["Description"].ToString();
                item.Number = (long)dr["Number"];
                item.SanadStatus = (EnSanadStatus)dr["SanadStatus"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.SumDebit = (decimal)dr["SumDebit"];
                item.SumCredit = (decimal)dr["SumCredit"];
                item.SanadType = (EnSanadType)dr["SanadType"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }

    }
}
