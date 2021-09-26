using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingRelatedNumberPersistenceRepository : IBuildingRelatedNumberRepository
    {
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRelatedNumberBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingRelatedNumber_Insert", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@buGuid", item.BuildingGuid);
                cmd.Parameters.AddWithValue("@number", item.Number ?? "");

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<BuildingRelatedNumberBussines> GetAsync(string connectionString, Guid buildingGuid)
        {
            var obj = new BuildingRelatedNumberBussines();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRelatedNumber_Get", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@buGuid", buildingGuid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read())
                    {
                        obj.BuildingGuid = buildingGuid;
                        obj.Number = dr["Number"].ToString();
                    }
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return obj;
        }
    }
}
