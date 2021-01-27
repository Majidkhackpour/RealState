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
    public class PeopleBankAccountPersistenceRepository : GenericRepository<PeoplesBankAccountBussines, PeopleBankAccount>, IPeoplesBankAccountRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PeopleBankAccountPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            var list = new List<PeoplesBankAccountBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_People_BankAccount_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@pGuid", parentGuid);
                    cmd.Parameters.AddWithValue("@st", status);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        private PeoplesBankAccountBussines LoadData(SqlDataReader dr)
        {
            var res = new PeoplesBankAccountBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.BankName = dr["BankName"].ToString();
                res.AccountNumber = dr["AccountNumber"].ToString();
                res.Shobe = dr["Shobe"].ToString();
                res.ParentGuid = (Guid)dr["ParentGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
