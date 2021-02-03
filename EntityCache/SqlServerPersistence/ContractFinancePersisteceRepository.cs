using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class ContractFinancePersisteceRepository : GenericRepository<ContractFinanceBussines, ContractFinance>, IContractFinanceRepository
    {
        private ModelContext db;
        private string _connectionString;
        public ContractFinancePersisteceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        public async Task<ContractFinanceBussines> GetAsync(Guid parentGuid, bool status)
        {
            var list = new ContractFinanceBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ContractFinance_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@conGuid", parentGuid);
                    cmd.Parameters.AddWithValue("@st", status);
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
        public async Task<decimal> GetTotalCommitionAsync(DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ContractFinance_GetTotalCommition", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null)
                        res = obj.ToString().ParseToDecimal();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        public async Task<decimal> GetTotalTaxAsync(DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ContractFinance_GetTotalTax", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@d1", d1);
                    cmd.Parameters.AddWithValue("@d2", d2);
                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null)
                        res = obj.ToString().ParseToDecimal();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        private ContractFinanceBussines LoadData(SqlDataReader dr)
        {
            var res = new ContractFinanceBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.ConGuid = (Guid)dr["ConGuid"];
                res.FirstDiscount = (decimal)dr["FirstDiscount"];
                res.SecondDiscount = (decimal)dr["SecondDiscount"];
                res.FirstAddedValue = (decimal)dr["FirstAddedValue"];
                res.SecondAddedValue = (decimal)dr["SecondAddedValue"];
                res.FirstTotalPrice = (decimal)dr["FirstTotalPrice"];
                res.SecondTotalPrice = (decimal)dr["SecondTotalPrice"];
                res.fBabat = (EnContractBabat)dr["fBabat"];
                res.sBabat = (EnContractBabat)dr["sBabat"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
