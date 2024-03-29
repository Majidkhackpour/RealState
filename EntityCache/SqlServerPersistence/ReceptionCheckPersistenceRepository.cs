﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using EntityCache.ViewModels;
using Persistence.Entities;
using Persistence.Model;
using Services;
using Services.DefaultCoding;

namespace EntityCache.SqlServerPersistence
{
    public class ReceptionCheckPersistenceRepository : IReceptionCheckRepository
    {
        private ReceptionCheckBussines LoadData(SqlDataReader dr)
        {
            var item = new ReceptionCheckBussines();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.Modified = (DateTime)dr["Modified"];
                item.BankName = dr["BankName"].ToString();
                item.DateM = (DateTime)dr["DateM"];
                if (dr["MasterGuid"] != DBNull.Value) item.MasterGuid = (Guid)dr["MasterGuid"];
                item.Description = dr["Description"].ToString();
                item.CheckNumber = dr["CheckNumber"].ToString();
                item.PoshtNomre = dr["PoshtNomre"].ToString();
                item.Price = (decimal)dr["Price"];
                item.CheckStatus = (EnCheckM)dr["CheckStatus"];
                item.DateSarResid = (DateTime)dr["DateSarResid"];
                item.SandouqTafsilGuid = (Guid)dr["SandouqTafsilGuid"];
                item.SandouqMoeinGuid = (Guid)dr["SandouqMoeinGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        private ReceptionCheckViewModel LoadDataViewModel(SqlDataReader dr)
        {
            var item = new ReceptionCheckViewModel();

            try
            {
                item.Guid = (Guid)dr["Guid"];
                item.BankName = dr["BankName"].ToString();
                item.DateM = (DateTime)dr["DateM"];
                item.Description = dr["Description"].ToString();
                item.CheckNumber = dr["CheckNumber"].ToString();
                item.PoshtNomre = dr["PoshtNomre"].ToString();
                item.Price = (decimal)dr["Price"];
                item.CheckStatus = (EnCheckM)dr["CheckStatus"];
                item.DateSarResid = (DateTime)dr["DateSarResid"];
                item.SandouqTafsilName = dr["SandouqTafsilName"].ToString();
                item.Pardazande = dr["Pardazande"].ToString();
                item.IsAvalDore = (bool)dr["AvalDore"];
                item.PardazandeGuid = (Guid)dr["PardazandeGuid"];
                item.SandouqTafsilGuid = (Guid)dr["SandouqTafsilGuid"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<List<ReceptionCheckBussines>> GetAllAsync(string _connectionString, Guid masterGuid)
        {
            var list = new List<ReceptionCheckBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheck_GetAll", cn)
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
        public async Task<ReceptionCheckBussines> GetAsync(string _connectionString, Guid guid)
        {
            ReceptionCheckBussines item = null;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheck_Get", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", guid);

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) item = LoadData(dr);
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return item;
        }
        public async Task<ReturnedSaveFuncInfo> RemoveRangeAsync(Guid masterGuid, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_ReceptionCheck_Remove", tr.Connection, tr)
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
        public async Task<List<ReceptionCheckViewModel>> GetAllViewModelAsync(string _connectionString)
        {
            var list = new List<ReceptionCheckViewModel>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_ReceptionCheck_GetAllFromView", cn)
                    { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(LoadDataViewModel(dr));
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SaveRangeAsync(IEnumerable<ReceptionCheckBussines> items, SqlTransaction tr)
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(ReceptionCheckBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_ReceptionCheck_Insert", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@bankName", item.BankName ?? "");
                cmd.Parameters.AddWithValue("@desc", item.Description ?? "");
                cmd.Parameters.AddWithValue("@dateM", item.DateM);
                cmd.Parameters.AddWithValue("@masterGuid", item.MasterGuid);
                cmd.Parameters.AddWithValue("@checkNumber", item.CheckNumber ?? "");
                cmd.Parameters.AddWithValue("@poshtNomre", item.PoshtNomre ?? "");
                cmd.Parameters.AddWithValue("@price", item.Price);
                cmd.Parameters.AddWithValue("@checkStatus", (int)item.CheckStatus);
                cmd.Parameters.AddWithValue("@sarResid", item.DateSarResid);
                cmd.Parameters.AddWithValue("@sandouqTafsilGuid", item.SandouqTafsilGuid);
                if (item.SandouqMoeinGuid == Guid.Empty)
                    item.SandouqMoeinGuid = ParentDefaults.MoeinCoding.CLSMoein10104;
                cmd.Parameters.AddWithValue("@sandouqMoeinGuid", item.SandouqMoeinGuid);
                cmd.Parameters.AddWithValue("@isAvalDore", item.isAvalDore);

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
