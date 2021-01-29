using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Nito.AsyncEx;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingRequestPersistenceRepository : GenericRepository<BuildingRequestBussines, BuildingRequest>, IBuildingRequestRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingRequestPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }

        public async Task<List<BuildingRequestBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<BuildingRequestBussines>("sp_BuildingsReq_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<int> DbCount(Guid userGuid)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Requests_Count", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@userGuid", userGuid);
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
        public override async Task<BuildingRequestBussines> GetAsync(Guid guid)
        {
            var list = new BuildingRequestBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRequest_Get", cn) { CommandType = CommandType.StoredProcedure };
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
        private BuildingRequestBussines LoadData(SqlDataReader dr)
        {
            var res = new BuildingRequestBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.AskerGuid = (Guid)dr["AskerGuid"];
                res.CreateDate = (DateTime)dr["CreateDate"];
                res.UserGuid = (Guid)dr["UserGuid"];
                res.SellPrice1 = (decimal)dr["SellPrice1"];
                res.SellPrice2 = (decimal)dr["SellPrice2"];
                res.HasVam = (bool?)dr["HasVam"];
                res.RahnPrice1 = (decimal)dr["RahnPrice1"];
                res.RahnPrice2 = (decimal)dr["RahnPrice2"];
                res.EjarePrice1 = (decimal)dr["EjarePrice1"];
                res.EjarePrice2 = (decimal)dr["EjarePrice2"];
                res.PeopleCount = (short?)dr["PeopleCount"];
                res.HasOwner = (bool?)dr["HasOwner"];
                res.ShortDate = (bool?)dr["ShortDate"];
                res.RentalAutorityGuid = (Guid?)dr["RentalAutorityGuid"];
                res.CityGuid = (Guid)dr["CityGuid"];
                res.BuildingTypeGuid = (Guid)dr["BuildingTypeGuid"];
                res.Masahat1 = (int)dr["Masahat1"];
                res.Masahat2 = (int)dr["Masahat2"];
                res.RoomCount = (int)dr["RoomCount"];
                res.BuildingAccountTypeGuid = (Guid)dr["BuildingAccountTypeGuid"];
                res.BuildingConditionGuid = (Guid)dr["BuildingConditionGuid"];
                res.ShortDesc = dr["ShortDesc"].ToString();
                res.RegionList = AsyncContext.Run(() => BuildingRequestRegionBussines.GetAllAsync(res.Guid, true));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
