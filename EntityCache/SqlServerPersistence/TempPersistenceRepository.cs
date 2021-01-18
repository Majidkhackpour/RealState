using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class TempPersistenceRepository : GenericRepository<TempBussines, Temp>, ITempRepository
    {
        private ModelContext db;
        private string connectionString;
        public TempPersistenceRepository(ModelContext _db, string _connectionString) : base(_db, _connectionString)
        {
            db = _db;
            connectionString = _connectionString;
        }

        public override async Task<ReturnedSaveFuncInfo> SaveAsync(TempBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Temp_Save", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", item.Guid);
                    cmd.Parameters.AddWithValue("@modif", item.Modified);
                    cmd.Parameters.AddWithValue("@type", (short)item.Type);
                    cmd.Parameters.AddWithValue("@objGuid", item.ObjectGuid);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public override async Task<List<TempBussines>> GetAllAsync()
        {
            var list = new List<TempBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Temp_GetAll", cn) { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadDataReader(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public override async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Temp_Remove", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private TempBussines LoadDataReader(SqlDataReader dr)
        {
            var item = new TempBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) item.Guid = (Guid)dr["Guid"];
                if (dr["Modified"] != DBNull.Value) item.Modified = (DateTime)dr["Modified"];
                if (dr["Status"] != DBNull.Value) item.Status = (bool)dr["Status"];
                if (dr["Type"] != DBNull.Value) item.Type = (EnTemp)dr["Type"];
                if (dr["ObjectGuid"] != DBNull.Value) item.ObjectGuid = (Guid)dr["ObjectGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
