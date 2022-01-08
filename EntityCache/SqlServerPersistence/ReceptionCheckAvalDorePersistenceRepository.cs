using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence;
using Persistence.Entities;
using Persistence.Model;
using Services;
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class ReceptionCheckAvalDorePersistenceRepository : IReceptionCheckAvalDoreRepository
    {
        private ReceptionCheckAvalDoreBussines LoadData(SqlDataReader dr)
        {
            var item = new ReceptionCheckAvalDoreBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
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
        public async Task<List<ReceptionCheckAvalDoreBussines>> GetAllAsync(string _connectionString)
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
        public async Task<ReceptionCheckAvalDoreBussines> GetAsync(string _connectionString, Guid guid)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionCheckAvalDoreBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_Save", tr.Connection,tr) { CommandType = CommandType.StoredProcedure };
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

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var item = await GetAsync(tr.Connection.ConnectionString, guid);
                var cmd = new SqlCommand("sp_ReceptionCheckAvalDore_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", guid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@sarmayeTafsilGuid", ParentDefaults.TafsilCoding.CLSTafsil5011001);
                cmd.Parameters.AddWithValue("@sarmayeMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein50110);
                cmd.Parameters.AddWithValue("@tafsilCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10304);
                cmd.Parameters.AddWithValue("@bankCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10101);
                cmd.Parameters.AddWithValue("@sandouqCreditMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10102);

                await cmd.ExecuteNonQueryAsync();
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
