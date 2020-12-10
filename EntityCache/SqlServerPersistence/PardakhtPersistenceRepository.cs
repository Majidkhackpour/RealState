using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    }
}
