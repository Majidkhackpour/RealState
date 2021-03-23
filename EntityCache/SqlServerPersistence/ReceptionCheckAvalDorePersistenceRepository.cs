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
    public class ReceptionCheckAvalDorePersistenceRepository : GenericRepository<ReceptionCheckAvalDoreBussines, ReceptionCheckAvalDore>, IReceptionCheckAvalDoreRepository
    {
        private ModelContext db;
        private string _connectionString;
        public ReceptionCheckAvalDorePersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        private ReceptionCheckAvalDoreBussines LoadData(SqlDataReader dr)
        {
            var item = new ReceptionCheckAvalDoreBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.BankName = dr["BankName"].ToString();
                item.DateM = (DateTime)dr["DateM"];
                item.DateSarResid = (DateTime)dr["DateSarResid"];
                item.Description = dr["Description"].ToString();
                item.CheckNumber = dr["CheckNumber"].ToString();
                item.PoshtNomre = dr["PoshtNomre"].ToString();
                item.Price = (decimal)dr["Price"];
                item.CheckStatus = (EnCheckM)dr["CheckStatus"];
                item.SandouqTafsilGuid = (Guid)dr["SandouqTafsilGuid"];
                item.SandouqName = dr["SandouqName"].ToString();
                item.SandouqMoeinGuid = (Guid)dr["SandouqMoeinGuid"];
                item.TafsilGuid = (Guid)dr["TafsilGuid"];
                item.TafsilName = dr["TafsilName"].ToString();
                item.UserGuid = (Guid)dr["UserGuid"];
                item.UserName = dr["UserName"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public override async Task<List<ReceptionCheckAvalDoreBussines>> GetAllAsync()
        {
            var list = new List<ReceptionCheckAvalDoreBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_GetAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<ReceptionCheckAvalDoreBussines> GetAsync(Guid guid)
        {
            ReceptionCheckAvalDoreBussines res = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionCheckAvalDoreBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@bankName", item.BankName ?? "");
                    cmd.Parameters.AddWithValue("@dateM", item.DateM);
                    cmd.Parameters.AddWithValue("@sarresid", item.DateSarResid);
                    cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                    cmd.Parameters.AddWithValue("@number", item.CheckNumber ?? "");
                    cmd.Parameters.AddWithValue("@poshNomre", item.PoshtNomre);
                    cmd.Parameters.AddWithValue("@price", item.Price);
                    cmd.Parameters.AddWithValue("@st", (int)item.CheckStatus);
                    cmd.Parameters.AddWithValue("@sandouqTafsilGuid", item.SandouqTafsilGuid);
                    if (item.SandouqMoeinGuid == Guid.Empty)
                        item.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104;
                    cmd.Parameters.AddWithValue("@sandouqMoeinGuid", item.SandouqMoeinGuid);
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
                    var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_Remove", cn) { CommandType = CommandType.StoredProcedure };
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
