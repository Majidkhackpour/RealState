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
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class PardakhtCheckAvalDorePersistenceRepository : GenericRepository<PardakhtCheckAvalDoreBussines, PardakhtCheckAvalDore>, IPardakhtCheckAvalDoreRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PardakhtCheckAvalDorePersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        private PardakhtCheckAvalDoreBussines LoadData(SqlDataReader dr)
        {
            var item = new PardakhtCheckAvalDoreBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.CheckPageGuid = (Guid)dr["CheckPageGuid"];
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.UserGuid = (Guid)dr["UserGuid"];
                item.DasteCheckName = dr["DasteCheckName"].ToString();
                item.Description = dr["Description"].ToString();
                item.Price = (decimal)dr["Price"];
                if (dr["DateSarresid"] != DBNull.Value) item.DateSarresid = (DateTime)dr["DateSarresid"];
                item.Number = dr["Number"].ToString();
                item.TafsilName = dr["TafsilName"].ToString();
                item.UserName = dr["UserName"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public override async Task<List<PardakhtCheckAvalDoreBussines>> GetAllAsync()
        {
            var list = new List<PardakhtCheckAvalDoreBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckAvalDore_GetAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<PardakhtCheckAvalDoreBussines> GetAsync(Guid guid)
        {
            PardakhtCheckAvalDoreBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckAvalDore_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtCheckAvalDoreBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckAvalDore_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@checkPageGuid", item.CheckPageGuid);
                    cmd.Parameters.AddWithValue("@dasteCheckName", item.DasteCheckName ?? "");
                    cmd.Parameters.AddWithValue("@tafsilGuid", item.TafsilGuid);
                    cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                    cmd.Parameters.AddWithValue("@sarmayeTafsilGuid", ParentDefaults.TafsilCoding.CLSTafsil5011001);
                    cmd.Parameters.AddWithValue("@sarmayeMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein50110);
                    cmd.Parameters.AddWithValue("@tafsilCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                    cmd.Parameters.AddWithValue("@bankCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10101);
                    cmd.Parameters.AddWithValue("@sandouqCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10102);

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
        public override async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var item = await GetAsync(guid);
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PardakhtCheckAvalDore_Remove", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                    cmd.Parameters.AddWithValue("@sarmayeTafsilGuid", ParentDefaults.TafsilCoding.CLSTafsil5011001);
                    cmd.Parameters.AddWithValue("@sarmayeMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein50110);
                    cmd.Parameters.AddWithValue("@tafsilCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                    cmd.Parameters.AddWithValue("@bankCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10101);
                    cmd.Parameters.AddWithValue("@sandouqCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10102);

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
