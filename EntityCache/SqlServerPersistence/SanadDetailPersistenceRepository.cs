using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
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
        public async Task<List<SanadDetailBussines>> GetAllAsync(Guid masterGuid)
        {
            var list = new List<SanadDetailBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SanadDetail_GetAllByMaster", cn)
                        {CommandType = CommandType.StoredProcedure};
                    cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(SanadDetailBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_SanadDetail_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@moeinGuid", item.MoeinGuid);
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                    cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                    cmd.Parameters.AddWithValue("@debit", item.Debit);
                    cmd.Parameters.AddWithValue("@credit", item.Credit);
                    cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
