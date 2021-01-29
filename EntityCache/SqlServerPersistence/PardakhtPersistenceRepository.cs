using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Bussines;
using EntityCache.Core;
using EntityCache.ViewModels;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class PardakhtPersistenceRepository : GenericRepository<PardakhtBussines, Pardakht>, IPardakhtRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PardakhtPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PardakhtBussines>> GetAllAsync(Guid payerGuid)
        {
            try
            {
                var acc = db.Pardakht.AsNoTracking()
                    .Where(q => q.Payer == payerGuid);

                return Mappings.Default.Map<List<PardakhtBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public async Task<int> DbCheckCount(string dateSh)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_CheckCount", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@dateSh", dateSh);
                    await cn.OpenAsync();
                    count = (int)await cmd.ExecuteScalarAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return count;
        }
        public async Task<List<CheckViewModel>> CheckReportAsync(string dateSh)
        {
            try
            {
                var ctGuid = new SqlParameter("@dateSh", dateSh);
                var res = db.Database.SqlQuery<CheckViewModel>("sp_Pardakht_CheckReport @dateSh", ctGuid);
                var a = res?.ToList();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(PardakhtBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@dateSh", item.DateSh);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@payer", item.Payer);
                    cmd.Parameters.AddWithValue("@createdate", item.CreateDate);
                    cmd.Parameters.AddWithValue("@desc", item.Description);
                    cmd.Parameters.AddWithValue("@naqdprice", item.NaqdPrice);
                    cmd.Parameters.AddWithValue("@bankprice", item.BankPrice);
                    cmd.Parameters.AddWithValue("@checkprice", item.Check);
                    cmd.Parameters.AddWithValue("@fishNo", item.FishNo);
                    cmd.Parameters.AddWithValue("@checkNo", item.CheckNo);
                    cmd.Parameters.AddWithValue("@sarresid", item.SarResid);
                    cmd.Parameters.AddWithValue("@bankname", item.BankName);

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
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(PardakhtBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_ChangeStatus", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@hesabGuid", item.Payer);
                    cmd.Parameters.AddWithValue("@st", !item.Status);
                    cmd.Parameters.AddWithValue("@price", item.TotalPrice);
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
        public override async Task<PardakhtBussines> GetAsync(Guid guid)
        {
            var list = new PardakhtBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Pardakht_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) list = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        private PardakhtBussines LoadData(SqlDataReader dr)
        {
            var res = new PardakhtBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.Payer = (Guid)dr["Payer"];
                res.CreateDate = (DateTime)dr["CreateDate"];
                res.NaqdPrice = (decimal)dr["NaqdPrice"];
                res.BankPrice = (decimal)dr["BankPrice"];
                res.FishNo = dr["FishNo"].ToString();
                res.Check = (decimal)dr["Check"];
                res.CheckNo = dr["CheckNo"].ToString();
                res.SarResid = dr["SarResid"].ToString();
                res.BankName = dr["BankName"].ToString();
                res.Description = dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
