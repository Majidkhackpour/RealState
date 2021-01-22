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
    public class ReceptionPersistenceRepository : GenericRepository<ReceptionBussines, Reception>, IReceptionRepository
    {
        private ModelContext db;
        private string _connectionString;
        public ReceptionPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<ReceptionBussines>> GetAllAsync(Guid receptioGuid)
        {
            try
            {
                var acc = db.Reception.AsNoTracking()
                    .Where(q => q.Receptor == receptioGuid);

                return Mappings.Default.Map<List<ReceptionBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@dateSh", item.DateSh);
                    cmd.Parameters.AddWithValue("@st", item.Status);
                    cmd.Parameters.AddWithValue("@receptor", item.Receptor);
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
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(ReceptionBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_ChangeStatus", cn)
                        { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@hesabGuid", item.Receptor);
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
        public async Task<int> DbCheckCount(string dateSh)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Reception_CheckCount", cn) { CommandType = CommandType.StoredProcedure };
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
                var res = db.Database.SqlQuery<CheckViewModel>("sp_Reception_CheckReport @dateSh", ctGuid);
                var a = res?.ToList();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
