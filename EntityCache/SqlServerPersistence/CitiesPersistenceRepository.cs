using System;
using System.Collections.Generic;
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
    public class CitiesPersistenceRepository : GenericRepository<CitiesBussines, Cities>, ICitiesRepository
    {
        private ModelContext db;
        private string _connectionString;
        public CitiesPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<bool> CheckNameAsync(Guid stateGuid, string name, Guid guid)
        {
            try
            {
                var acc = db.Cities.AsNoTracking()
                    .Where(q => q.Name == name && q.StateGuid == stateGuid && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return false;
            }
        }
        public async Task<List<CitiesBussines>> GetAllAsync(Guid stateGuid)
        {
            try
            {
                var ctGuid = new SqlParameter("@stateGuid", stateGuid);
                var res = db.Database.SqlQuery<CitiesBussines>("sp_Cities_SelectAllByStateGuid @stateGuid", ctGuid);
                var a = res.ToList();
                return a;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public async Task<List<CitiesBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<CitiesBussines>("sp_Cities_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public override async Task<CitiesBussines> GetAsync(Guid guid)
        {
            var obj = new CitiesBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Cities_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        private CitiesBussines LoadData(SqlDataReader dr)
        {
            var item = new CitiesBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.StateGuid = (Guid)dr["StateGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
