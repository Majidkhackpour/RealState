﻿using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class TempPersistenceRepository : ITempRepository
    {
        public async Task<ReturnedSaveFuncInfo> SaveAsync(TempBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Temp_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@type", (short)item.Type);
                cmd.Parameters.AddWithValue("@objGuid", item.ObjectGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task UpdateEntityAsync(EnTemp type, Guid entityGuid, ServerStatus st, DateTime deliveryDate, string connectionString)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Temp_UpdateEntities", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@type", (short)type);
                    cmd.Parameters.AddWithValue("@entityGuid", entityGuid);
                    cmd.Parameters.AddWithValue("@st", (short)st);
                    cmd.Parameters.AddWithValue("@deliveryDate", deliveryDate);

                    await cn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public async Task<List<TempBussines>> GetAllAsync(string connectionString)
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
                if (!ex.Message.Contains("deadlocked"))
                    WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync(Guid guid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Temp_Remove", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", guid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveOnModifiedAsync(DateTime date, string connectionString)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Temp_SaveOnModified", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@date", date);

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
