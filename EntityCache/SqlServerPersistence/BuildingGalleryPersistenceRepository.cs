using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingGalleryPersistenceRepository : GenericRepository<BuildingGalleryBussines, BuildingGallery>, IBuildingGalleryRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingGalleryPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<BuildingGalleryBussines>> GetAllAsync(Guid parentGuid, bool status)
        {
            var list = new List<BuildingGalleryBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingGallery_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@buGuid", parentGuid);
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
        private BuildingGalleryBussines LoadData(SqlDataReader dr)
        {
            var res = new BuildingGalleryBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.BuildingGuid = (Guid)dr["BuildingGuid"];
                res.ImageName = dr["ImageName"].ToString();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
