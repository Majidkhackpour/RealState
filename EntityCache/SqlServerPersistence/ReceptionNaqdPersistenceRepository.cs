﻿using System;
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
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class ReceptionNaqdPersistenceRepository : IReceptionNaqdRepository
    {
        private ReceptionNaqdBussines LoadData(SqlDataReader dr)
        {
            var item = new ReceptionNaqdBussines();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.DateM = (DateTime)dr["DateM"];
                item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Description = dr["Description"].ToString();
                item.Price = (decimal)dr["Price"];
                item.SandouqTafsilGuid = (Guid)dr["SandouqTafsilGuid"];
                item.SandouqMoeinGuid = (Guid)dr["SandouqMoeinGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<ReceptionNaqdBussines>> GetAllAsync(string _connectionString, Guid masterGuid)
        {
            var list = new List<ReceptionNaqdBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionNaqd_GetAll", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

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
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_ReceptionNaqd_Remove", tr.Connection, tr)
                { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@masterGuid", masterGuid);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<ReceptionNaqdBussines> items, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (items == null || !items.Any()) return res;
                foreach (var item in items)
                    res.AddReturnedValue(await SaveAsync(item, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionNaqdBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_ReceptionNaqd_Insert", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@sandouqTafsilGuid", item.SandouqTafsilGuid);
                cmd.Parameters.AddWithValue("@sandouqMoeinGuid", ParentDefaults.MoeinCoding.CLSMoein10102);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
    }
}
