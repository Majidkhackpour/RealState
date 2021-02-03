using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class HazinePersistenceRepository : GenericRepository<HazineBussines, Hazine>, IHazineRepository
    {
        private ModelContext db;
        private string _connectionString;
        public HazinePersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckNameAsync(string name, Guid guid)
        {
            try
            {
                var acc = db.Hazine.AsNoTracking()
                    .Where(q => q.Name == name && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
        public async Task<decimal> GetTotalHazineAsync(DateTime d1, DateTime d2)
        {
            var res = (decimal)0;
            try
            {
                var all = await GetAllAsync();
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Hazine_GetTotal", cn) { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    foreach (var item in all)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@d1", d1);
                        cmd.Parameters.AddWithValue("@d2", d2);
                        cmd.Parameters.AddWithValue("@hazineGuid", item.Guid);
                        var obj = await cmd.ExecuteScalarAsync();
                        if (obj != null)
                            res += obj.ToString().ParseToDecimal();
                    }

                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return res;
        }
        public override async Task<HazineBussines> GetAsync(Guid guid)
        {
            var obj = new HazineBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Hazine_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) obj = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return obj;
        }
        private HazineBussines LoadData(SqlDataReader dr)
        {
            var item = new HazineBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.Account = (decimal)dr["Account"];
                item.AccountFirst = (decimal) dr["AccountFirst"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
