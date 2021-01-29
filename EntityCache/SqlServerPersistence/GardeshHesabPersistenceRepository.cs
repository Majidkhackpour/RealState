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
    public class GardeshHesabPersistenceRepository : GenericRepository<GardeshHesabBussines, GardeshHesab>, IGardeshHesabRepository
    {
        private ModelContext db;
        private string _connectionString;
        public GardeshHesabPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<GardeshHesabBussines> GetAsync(Guid hesabGuid, Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking().FirstOrDefault(q =>
                    q.ParentGuid == parentGuid && q.PeopleGuid == hesabGuid && q.Status == status);

                return Mappings.Default.Map<GardeshHesabBussines>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public async Task<List<GardeshHesabBussines>> GetAllAsync(Guid hesabGuid)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking()
                    .Where(q => q.PeopleGuid == hesabGuid).ToList();

                return Mappings.Default.Map<List<GardeshHesabBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public async Task<List<GardeshHesabBussines>> GetAllBySpAsync()
        {
            try
            {
                var res = db.Database.SqlQuery<GardeshHesabBussines>("sp_Gardesh_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<List<GardeshHesabBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            try
            {
                var acc = db.GardeshHesab.AsNoTracking()
                    .Where(q => q.ParentGuid == parentGuid && q.Status == status).ToList();

                return Mappings.Default.Map<List<GardeshHesabBussines>>(acc);
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return null;
            }
        }
        public override async Task<GardeshHesabBussines> GetAsync(Guid guid)
        {
            var list = new GardeshHesabBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_GardeshHesab_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        private GardeshHesabBussines LoadData(SqlDataReader dr)
        {
            var res = new GardeshHesabBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.PeopleGuid = (Guid)dr["PeopleGuid"];
                res.Price = (decimal)dr["Price"];
                res.Type = (EnAccountType)dr["Type"];
                res.Babat = (EnAccountBabat)dr["Babat"];
                res.ParentGuid = (Guid)dr["ParentGuid"];
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
