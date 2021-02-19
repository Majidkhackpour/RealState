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
    public class CheckPagePersistenceRepository : GenericRepository<CheckPageBussines, CheckPage>, ICheckPageRepository
    {
        private ModelContext db;

        private string _connectionString;
        public CheckPagePersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        private CheckPageBussines LoadData(SqlDataReader dr)
        {
            var item = new CheckPageBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.CheckGuid = (Guid)dr["CheckGuid"];
                item.DatePardakht = (DateTime?)dr["DatePardakht"];
                item.Number = (long)dr["Number"];
                item.ReceptorGuid = (Guid?)dr["ReceptorGuid"];
                item.DateSarresid = (DateTime?)dr["DateSarresid"];
                item.Description = dr["Description"].ToString();
                item.Price = (decimal)dr["Price"];
                item.CheckStatus = (EnCheckSh)dr["CheckStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<CheckPageBussines>> GetAllAsync(Guid checkGuid)
        {
            var list = new List<CheckPageBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_CheckPage_SelectAll", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", checkGuid);

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
        public override async Task<CheckPageBussines> GetAsync(Guid guid)
        {
            CheckPageBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_CheckPage_SelectRow", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) res = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(CheckPageBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_CheckPage_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@CheckGuid", item.CheckGuid);
                    cmd.Parameters.AddWithValue("@datePardakht", item.DatePardakht);
                    cmd.Parameters.AddWithValue("@number", item.Number);
                    cmd.Parameters.AddWithValue("@receptorGuid", item.ReceptorGuid);
                    cmd.Parameters.AddWithValue("@sarresid", item.DateSarresid);
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.Parameters.AddWithValue("@st", (int)item.CheckStatus);

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
        public override async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid checkGuid, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_CheckPage_RemoveAll", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", checkGuid);

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
