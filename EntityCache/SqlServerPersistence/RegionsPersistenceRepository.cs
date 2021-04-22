﻿using EntityCache.Bussines;
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
    public class RegionsPersistenceRepository : IRegionsRepository
    {
        public async Task<List<RegionsBussines>> GetAllAsync(string _connectionString, Guid cityGuid)
        {
            var list = new List<RegionsBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Regions_SelectAllByCityGuid", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@cityGuid", cityGuid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<RegionsBussines>> GetAllAsync(string _connectionString)
        {
            var list = new List<RegionsBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Regions_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadData(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<RegionsBussines> GetAsync(string _connectionString, string name)
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
        public async Task<RegionsBussines> GetAsync(string _connectionString, Guid guid)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(RegionsBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Regions_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@name", item.Name ?? "");
                cmd.Parameters.AddWithValue("@cityGuid", item.CityGuid);
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<RegionsBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in items)
                {
                    res.AddReturnedValue(await SaveAsync(item, tr));
                    if (res.HasError) return res;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(RegionsBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Regions_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", status);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
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
                item.CityName = dr["CityName"].ToString();
                item.StateName = dr["StateName"].ToString();
                item.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                item.ServerStatus = (ServerStatus)dr["ServerStatus"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
    }
}
