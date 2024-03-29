﻿using EntityCache.Bussines;
using EntityCache.Core;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingRequestPersistenceRepository : IBuildingRequestRepository
    {
        private BuildingRequestRegionPersistenceRepository _regions = null;
        public BuildingRequestPersistenceRepository()
        {
            _regions = new BuildingRequestRegionPersistenceRepository();
        }
        public async Task<List<BuildingRequestBussines>> GetAllAsync(string _connectionString, bool status, CancellationToken token)
        {
            var list = new List<BuildingRequestBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingsReq_SelectAll", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@st", status);
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(await LoadDataAsync(dr, false, _connectionString));
                    }
                    cn.Close();
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<int> DbCount(string _connectionString, Guid userGuid)
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
        public async Task<BuildingRequestBussines> GetAsync(string _connectionString, Guid guid)
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
                    if (dr.Read()) list = await LoadDataAsync(dr, true, _connectionString);
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingRequestBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingRequest_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingRequestBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await SaveAsync_(item, tr));

                res.AddReturnedValue(await _regions.RemoveRangeAsync(item.Guid, tr));
                if (res.HasError) return res;

                if (item.RegionList.Count > 0)
                {
                    foreach (var op in item.RegionList)
                        op.RequestGuid = item.Guid;
                    res.AddReturnedValue(await _regions.SaveRangeAsync(item.RegionList, tr));
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
        private async Task<ReturnedSaveFuncInfo> SaveAsync_(BuildingRequestBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_BuildingRequest_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@createDtae", item.CreateDate);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@askerGuid", item.AskerGuid);
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@sellPrice1", item.SellPrice1);
                cmd.Parameters.AddWithValue("@sellPrice2", item.SellPrice2);
                cmd.Parameters.AddWithValue("@hasVam", item.HasVam);
                cmd.Parameters.AddWithValue("@rahn1", item.RahnPrice1);
                cmd.Parameters.AddWithValue("@rahn2", item.RahnPrice2);
                cmd.Parameters.AddWithValue("@ejare1", item.EjarePrice1);
                cmd.Parameters.AddWithValue("@ejare2", item.EjarePrice2);
                cmd.Parameters.AddWithValue("@peopleCount", item.PeopleCount);
                cmd.Parameters.AddWithValue("@hasOwner", item.HasOwner);
                cmd.Parameters.AddWithValue("@shortDate", item.ShortDate);
                cmd.Parameters.AddWithValue("@rentalGuid", item.RentalAutorityGuid);
                cmd.Parameters.AddWithValue("@cityGuid", item.CityGuid);
                cmd.Parameters.AddWithValue("@typeGuid", item.BuildingTypeGuid);
                cmd.Parameters.AddWithValue("@masahat1", item.Masahat1);
                cmd.Parameters.AddWithValue("@masahat2", item.Masahat2);
                cmd.Parameters.AddWithValue("@roomCount", item.RoomCount);
                cmd.Parameters.AddWithValue("@accTypeGuid", item.BuildingAccountTypeGuid);
                cmd.Parameters.AddWithValue("@conditionGuid", item.BuildingConditionGuid);
                cmd.Parameters.AddWithValue("@shortDesc", item.ShortDesc ?? "");
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
        public async Task<ReturnedSaveFuncInfo> DeleteAsync(string connectionString, DateTime date)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRequest_DeleteAfter60Days", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<BuildingRequestBussines>> GetAllNotSentAsync(string connectionString)
        {
            var list = new List<BuildingRequestBussines>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRequest_GetAllNotSent", cn) { CommandType = CommandType.StoredProcedure };
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(await LoadDataBussinesAsync(dr, connectionString));
                    dr.Close();
                    cn.Close();
                }
            }
            catch (TaskCanceledException) { }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(string connectionString, Guid guid, ServerStatus status)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRequest_SetSaveResult", cn)
                    { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", guid);
                    cmd.Parameters.AddWithValue("@st", (short)status);
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
        public async Task<ReturnedSaveFuncInfo> ResetAsync(string connectionString)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_BuildingRequest_Reset", cn)
                    { CommandType = CommandType.StoredProcedure };
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
        private async Task<BuildingRequestBussines> LoadDataAsync(SqlDataReader dr, bool isLoadDet, string connectionString)
        {
            var res = new BuildingRequestBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.AskerGuid = (Guid)dr["AskerGuid"];
                res.AskerName = dr["AskerName"].ToString();
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
                res.UserName = dr["UserName"].ToString();
                res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                res.ServerStatus = (ServerStatus)dr["ServerStatus"];
                res.IsModified = true;
                if (isLoadDet)
                    res.RegionList = await _regions.GetAllAsync(connectionString, res.Guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        private async Task<BuildingRequestBussines> LoadDataBussinesAsync(SqlDataReader dr, string connectionString)
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
                res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                res.ServerStatus = (ServerStatus)dr["ServerStatus"];
                res.RegionList = await _regions.GetAllAsync(connectionString, res.Guid);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
