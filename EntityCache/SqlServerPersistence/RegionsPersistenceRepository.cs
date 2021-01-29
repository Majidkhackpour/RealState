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
    public class RegionsPersistenceRepository : GenericRepository<RegionsBussines, Regions>, IRegionsRepository
    {
        private ModelContext db;
        private string _connectionString;
        public RegionsPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<RegionsBussines>> GetAllAsync(Guid cityGuid)
        {
            try
            {
                var ctGuid = new SqlParameter("@cityGuid", cityGuid);
                var res = db.Database.SqlQuery<RegionsBussines>("sp_Regions_SelectAllByCityGuid @cityGuid", ctGuid);
                var a = res.ToList();
                return a;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public async Task<List<RegionsBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<RegionsBussines>("sp_Regions_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<RegionsBussines> GetAsync(string name)
        {
            var obj = new RegionsBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Regions_GetByName", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@name", name);
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
        public override async Task<RegionsBussines> GetAsync(Guid guid)
        {
            var obj = new RegionsBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Regions_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        private RegionsBussines LoadData(SqlDataReader dr)
        {
            var item = new RegionsBussines();
            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.Status = (bool)dr["Status"];
                item.Name = dr["Name"].ToString();
                item.CityGuid = (Guid)dr["CityGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
