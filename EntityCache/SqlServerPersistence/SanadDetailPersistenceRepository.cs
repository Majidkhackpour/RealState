using System;
using System.Data.SqlClient;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class SanadDetailPersistenceRepository : GenericRepository<SanadDetailBussines, SanadDetail>, ISanadDetailRepository
    {
        private ModelContext db;
        private string _connectionString;
        public SanadDetailPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        private SanadDetailBussines LoadData(SqlDataReader dr)
        {
            var item = new SanadDetailBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.MoeinGuid = (Guid)dr["MoeinGuid"];
                item.MoeinCode = dr["MoeinCode"].ToString();
                item.MoeinName = dr["MoeinName"].ToString();
                item.TafsilGuid = (Guid) dr["TafsilGuid"];
                item.TafsilCode = dr["TafsilCode"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.Description = dr["Description"].ToString();
                item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Debit = (decimal)dr["Debit"];
                item.Credit = (decimal)dr["Credit"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
