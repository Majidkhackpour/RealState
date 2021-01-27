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
    public class PhoneBookPersistenceRepository : GenericRepository<PhoneBookBussines, PhoneBook>, IPhoneBookRepository
    {
        private ModelContext db;
        private string _connectionString;
        public PhoneBookPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            var list = new List<PhoneBookBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_PhoneBook_GetAll", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<PhoneBookBussines>> GetAllBySpAsync(Guid parentGuid, bool status)
        {
            try
            {
                var res = db.Database.SqlQuery<PhoneBookBussines>("sp_PhoneBook_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        private PhoneBookBussines LoadData(SqlDataReader dr)
        {
            var res = new PhoneBookBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.Name = dr["Name"].ToString();
                res.Tell = dr["Tell"].ToString();
                res.Group = (EnPhoneBookGroup)dr["Group"];
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
