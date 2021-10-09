using EntityCache.Bussines;
using EntityCache.Core;
using Nito.AsyncEx;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingPersistenceRepository : IBuildingRepository
    {
        public async Task<List<BuildingBussines>> GetAllAsync(string _connectionString, CancellationToken token, bool isLoadDets)
        {
            var list = new List<BuildingBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Buildings_SelectAll", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadData(dr, isLoadDets));
                    }
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
        public async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines item, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Building_Save", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@guid", item.Guid);
                cmd.Parameters.AddWithValue("@st", item.Status);
                cmd.Parameters.AddWithValue("@ownerGuid", item.OwnerGuid);
                cmd.Parameters.AddWithValue("@modif", item.Modified);
                cmd.Parameters.AddWithValue("@sellPrice", item.SellPrice);
                cmd.Parameters.AddWithValue("@vamPrice", item.VamPrice);
                cmd.Parameters.AddWithValue("@qestPrice", item.QestPrice);
                cmd.Parameters.AddWithValue("@dong", item.Dang);
                cmd.Parameters.AddWithValue("@docTypeGuid", item.DocumentType);
                cmd.Parameters.AddWithValue("@tarakom", item.Tarakom);
                cmd.Parameters.AddWithValue("@rahnPrice1", item.RahnPrice1);
                cmd.Parameters.AddWithValue("@ejarePrice1", item.EjarePrice1);
                cmd.Parameters.AddWithValue("@rentalGuid", item.RentalAutorityGuid);
                cmd.Parameters.AddWithValue("@isShortTime", item.IsShortTime);
                cmd.Parameters.AddWithValue("@isOwnerHere", item.IsOwnerHere);
                cmd.Parameters.AddWithValue("@pishTotalPrice", item.PishTotalPrice);
                cmd.Parameters.AddWithValue("@pishPrice", item.PishPrice);
                cmd.Parameters.AddWithValue("@deliveryDate", item.DeliveryDate);
                cmd.Parameters.AddWithValue("@pishDesc", item.PishDesc ?? "");
                cmd.Parameters.AddWithValue("@moavezeDesc", item.MoavezeDesc ?? "");
                cmd.Parameters.AddWithValue("@mosharekatDesc", item.MosharekatDesc ?? "");
                cmd.Parameters.AddWithValue("@masahat", item.Masahat);
                cmd.Parameters.AddWithValue("@zirbana", item.ZirBana);
                cmd.Parameters.AddWithValue("@cityGuid", item.CityGuid);
                cmd.Parameters.AddWithValue("@regionGuid", item.RegionGuid);
                cmd.Parameters.AddWithValue("@address", item.Address ?? "");
                cmd.Parameters.AddWithValue("@conditionGuid", item.BuildingConditionGuid);
                if (item.Side != null)
                    cmd.Parameters.AddWithValue("@side", (int)item.Side);
                cmd.Parameters.AddWithValue("@typeGuid", item.BuildingTypeGuid);
                cmd.Parameters.AddWithValue("@shortDesc", item.ShortDesc ?? "");
                cmd.Parameters.AddWithValue("@accountTypeGuid", item.BuildingAccountTypeGuid);
                cmd.Parameters.AddWithValue("@metrazhTejari", item.MetrazhTejari);
                cmd.Parameters.AddWithValue("@viewGuid", item.BuildingViewGuid);
                cmd.Parameters.AddWithValue("@floorCoverGuid", item.FloorCoverGuid);
                cmd.Parameters.AddWithValue("@kitchenServiceGuid", item.KitchenServiceGuid);
                if (item.Water != null)
                    cmd.Parameters.AddWithValue("@water", (short)item.Water);
                if (item.Barq != null)
                    cmd.Parameters.AddWithValue("@barq", (short)item.Barq);
                if (item.Gas != null)
                    cmd.Parameters.AddWithValue("@gas", (short)item.Gas);
                if (item.Tell != null)
                    cmd.Parameters.AddWithValue("@tell", (short)item.Tell);
                cmd.Parameters.AddWithValue("@tedadTabaqe", item.TedadTabaqe);
                cmd.Parameters.AddWithValue("@tabaqeNo", item.TabaqeNo);
                cmd.Parameters.AddWithValue("@vahedPerTabaqe", item.VahedPerTabaqe);
                cmd.Parameters.AddWithValue("@metrazheKouche", item.MetrazhKouche);
                cmd.Parameters.AddWithValue("@ertefaSaqf", item.ErtefaSaqf);
                cmd.Parameters.AddWithValue("@hashie", item.Hashie);
                cmd.Parameters.AddWithValue("@saleSakht", item.SaleSakht ?? "");
                cmd.Parameters.AddWithValue("@dateParvane", item.DateParvane ?? "");
                cmd.Parameters.AddWithValue("@parvaneSerial", item.ParvaneSerial ?? "");
                cmd.Parameters.AddWithValue("@bonBast", item.BonBast);
                cmd.Parameters.AddWithValue("@mamarJoda", item.MamarJoda);
                cmd.Parameters.AddWithValue("@roomCount", item.RoomCount);
                cmd.Parameters.AddWithValue("@code", item.Code ?? "");
                cmd.Parameters.AddWithValue("@userGuid", item.UserGuid);
                cmd.Parameters.AddWithValue("@createDate", item.CreateDate);
                cmd.Parameters.AddWithValue("@image", item.Image ?? "");
                cmd.Parameters.AddWithValue("@priority", (short)item.Priority);
                cmd.Parameters.AddWithValue("@isArchive", item.IsArchive);
                cmd.Parameters.AddWithValue("@serverSt", (short)item.ServerStatus);
                cmd.Parameters.AddWithValue("@serverDate", item.ServerDeliveryDate);
                cmd.Parameters.AddWithValue("@lenght", item.Lenght);
                cmd.Parameters.AddWithValue("@telegramCount", item.TelegramCount);
                cmd.Parameters.AddWithValue("@divarCount", item.DivarCount);
                cmd.Parameters.AddWithValue("@sheypoorCount", item.SheypoorCount);
                if (item.AdvertiseType != null)
                    cmd.Parameters.AddWithValue("@advType", (short)item.AdvertiseType);
                cmd.Parameters.AddWithValue("@divarTitle", item.DivarTitle ?? "");
                cmd.Parameters.AddWithValue("@hitting", item.Hiting ?? "");
                cmd.Parameters.AddWithValue("@colling", item.Colling ?? "");
                cmd.Parameters.AddWithValue("@whatsAppCount", item.WhatsAppCount);
                cmd.Parameters.AddWithValue("@tabdil", item.Tabdil);
                cmd.Parameters.AddWithValue("@reformArear", item.ReformArea);
                cmd.Parameters.AddWithValue("@buildingPermits", item.BuildingPermits);
                cmd.Parameters.AddWithValue("@widthOfPassage", item.WidthOfPassage);
                if (item.VillaType != null)
                    cmd.Parameters.AddWithValue("@villaType", (short)item.VillaType);
                if (item.CommericallLicense != null)
                    cmd.Parameters.AddWithValue("@commeriacallLicense", (short)item.CommericallLicense);
                cmd.Parameters.AddWithValue("@suitableFor", item.SuitableFor ?? "");
                cmd.Parameters.AddWithValue("@wallCovering", item.WallCovering ?? "");
                cmd.Parameters.AddWithValue("@treeCount", item.TreeCount);
                if (item.ConstructionStage != null)
                    cmd.Parameters.AddWithValue("@constructionStage", (short)item.ConstructionStage);
                if (item.Parent != null)
                    cmd.Parameters.AddWithValue("@parent", (short)item.Parent);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingBussines item, bool status, SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var cmd = new SqlCommand("sp_Building_ChangeStatus", tr.Connection, tr) { CommandType = CommandType.StoredProcedure };
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
        public async Task<string> NextCodeAsync(string _connectionString)
        {
            var res = "0";
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_NextCode", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var obj = await cmd.ExecuteScalarAsync();
                    if (obj != null) res = obj.ToString();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
        public async Task<bool> CheckCodeAsync(string _connectionString, string code, Guid guid)
        {
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_CheckCode", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    cmd.Parameters.AddWithValue("@code", code);

                    await cn.OpenAsync();
                    var count = (int)await cmd.ExecuteScalarAsync();
                    cn.Close();
                    return count <= 0;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public async Task<int> DbCount(string _connectionString, Guid userGuid, short type)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_Count", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@userGuid", userGuid);
                    cmd.Parameters.AddWithValue("@type", type);
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
        public async Task<ReturnedSaveFuncInfo> FixImageAsync(string _connectionString)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_FixImages", cn) { CommandType = CommandType.StoredProcedure };

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
        public async Task<BuildingBussines> GetAsync(string _connectionString, Guid guid)
        {
            var list = new BuildingBussines();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Buildings_GetByGuid", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@guid", guid);
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    if (dr.Read()) list = LoadData(dr, true);
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
            }

            return list;
        }
        public async Task<ReturnedSaveFuncInfo> SetArchiveAsync(string _connectionString, DateTime date)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_SetArchive", cn) { CommandType = CommandType.StoredProcedure };
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
        public async Task<List<BuildingBussines>> GetAllHighPriorityAsync(string _connectionString, CancellationToken token)
        {
            var list = new List<BuildingBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_GetAllHighPriority", cn) { CommandType = CommandType.StoredProcedure };
                    if (token.IsCancellationRequested) return null;
                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read())
                    {
                        if (token.IsCancellationRequested) return null;
                        list.Add(LoadData(dr, true));
                    }
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
        public async Task<bool> CheckDuplicateAsync(string connectionString, string divarTitle)
        {
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Buildings_CheckDuplicate", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@divarTitle", divarTitle ?? "");

                    await cn.OpenAsync();
                    var count = await cmd.ExecuteScalarAsync();
                    if (count == null) return false;
                    var x = count.ToString().ParseToInt();
                    return x > 0;
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return false;
            }
        }
        public async Task<List<string>> GetAllHittingAsync(string connectionString)
        {
            var list = new List<string>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_GetHitting", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(dr["Hiting"].ToString());
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        public async Task<List<string>> GetAllCollingAsync(string connectionString)
        {
            var list = new List<string>();
            try
            {
                using (var cn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_GetColling", cn) { CommandType = CommandType.StoredProcedure };

                    await cn.OpenAsync();
                    var dr = await cmd.ExecuteReaderAsync();
                    while (dr.Read()) list.Add(dr["Colling"].ToString());
                    dr.Close();
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return list;
        }
        private BuildingBussines LoadData(SqlDataReader dr, bool isLoadDets)
        {
            var res = new BuildingBussines();
            try
            {
                if (dr["Guid"] != DBNull.Value) res.Guid = (Guid)dr["Guid"];
                if (dr["OwnerGuid"] != DBNull.Value) res.OwnerGuid = (Guid)dr["OwnerGuid"];
                if (dr["SellPrice"] != DBNull.Value) res.SellPrice = (decimal)dr["SellPrice"];
                if (dr["Modified"] != DBNull.Value) res.Modified = (DateTime)dr["Modified"];
                if (dr["Status"] != DBNull.Value) res.Status = (bool)dr["Status"];
                if (dr["Code"] != DBNull.Value) res.Code = dr["Code"].ToString();
                if (dr["VamPrice"] != DBNull.Value) res.VamPrice = (decimal)dr["VamPrice"];
                if (dr["QestPrice"] != DBNull.Value) res.QestPrice = (decimal)dr["QestPrice"];
                if (dr["Dang"] != DBNull.Value) res.Dang = (int)dr["Dang"];
                if (dr["DocumentType"] != DBNull.Value) res.DocumentType = (Guid)dr["DocumentType"];
                if (dr["Tarakom"] != DBNull.Value)
                {
                    var tr = dr["Tarakom"].ToString().ParseToShort();
                    res.Tarakom = (EnTarakom?)tr;
                }
                if (dr["RahnPrice1"] != DBNull.Value) res.RahnPrice1 = (decimal)dr["RahnPrice1"];
                if (dr["EjarePrice1"] != DBNull.Value) res.EjarePrice1 = (decimal)dr["EjarePrice1"];
                if (dr["RentalAutorityGuid"] != DBNull.Value) res.RentalAutorityGuid = (Guid?)dr["RentalAutorityGuid"];
                if (dr["IsShortTime"] != DBNull.Value) res.IsShortTime = (bool)dr["IsShortTime"];
                if (dr["IsOwnerHere"] != DBNull.Value) res.IsOwnerHere = (bool)dr["IsOwnerHere"];
                if (dr["PishTotalPrice"] != DBNull.Value) res.PishTotalPrice = (decimal)dr["PishTotalPrice"];
                if (dr["PishPrice"] != DBNull.Value) res.PishPrice = (decimal)dr["PishPrice"];
                if (dr["DeliveryDate"] != DBNull.Value) res.DeliveryDate = (DateTime?)dr["DeliveryDate"];
                if (dr["PishDesc"] != DBNull.Value) res.PishDesc = dr["PishDesc"].ToString();
                if (dr["MoavezeDesc"] != DBNull.Value) res.MoavezeDesc = dr["MoavezeDesc"].ToString();
                if (dr["MosharekatDesc"] != DBNull.Value) res.MosharekatDesc = dr["MosharekatDesc"].ToString();
                if (dr["UserGuid"] != DBNull.Value) res.UserGuid = (Guid)dr["UserGuid"];
                if (dr["Masahat"] != DBNull.Value) res.Masahat = (int)dr["Masahat"];
                if (dr["ZirBana"] != DBNull.Value) res.ZirBana = (int)dr["ZirBana"];
                if (dr["CityGuid"] != DBNull.Value) res.CityGuid = (Guid)dr["CityGuid"];
                if (dr["RegionGuid"] != DBNull.Value) res.RegionGuid = (Guid)dr["RegionGuid"];
                if (dr["Address"] != DBNull.Value) res.Address = dr["Address"].ToString();
                if (dr["BuildingConditionGuid"] != DBNull.Value) res.BuildingConditionGuid = (Guid)dr["BuildingConditionGuid"];
                if (dr["Side"] != DBNull.Value) res.Side = (EnBuildingSide)dr["Side"];
                if (dr["BuildingTypeGuid"] != DBNull.Value) res.BuildingTypeGuid = (Guid)dr["BuildingTypeGuid"];
                if (dr["ShortDesc"] != DBNull.Value) res.ShortDesc = dr["ShortDesc"].ToString();
                if (dr["BuildingAccountTypeGuid"] != DBNull.Value) res.BuildingAccountTypeGuid = (Guid)dr["BuildingAccountTypeGuid"];
                if (dr["MetrazhTejari"] != DBNull.Value) res.MetrazhTejari = (float)dr["MetrazhTejari"];
                if (dr["BuildingViewGuid"] != DBNull.Value) res.BuildingViewGuid = (Guid)dr["BuildingViewGuid"];
                if (dr["FloorCoverGuid"] != DBNull.Value) res.FloorCoverGuid = (Guid)dr["FloorCoverGuid"];
                if (dr["KitchenServiceGuid"] != DBNull.Value) res.KitchenServiceGuid = (Guid)dr["KitchenServiceGuid"];
                if (dr["Water"] != DBNull.Value) res.Water = (EnKhadamati)dr["Water"];
                if (dr["Barq"] != DBNull.Value) res.Barq = (EnKhadamati)dr["Barq"];
                if (dr["Gas"] != DBNull.Value) res.Gas = (EnKhadamati)dr["Gas"];
                if (dr["Tell"] != DBNull.Value) res.Tell = (EnKhadamati)dr["Tell"];
                if (dr["TedadTabaqe"] != DBNull.Value) res.TedadTabaqe = (int)dr["TedadTabaqe"];
                if (dr["TabaqeNo"] != DBNull.Value) res.TabaqeNo = (int)dr["TabaqeNo"];
                if (dr["VahedPerTabaqe"] != DBNull.Value) res.VahedPerTabaqe = (int)dr["VahedPerTabaqe"];
                if (dr["MetrazhKouche"] != DBNull.Value) res.MetrazhKouche = (float)dr["MetrazhKouche"];
                if (dr["ErtefaSaqf"] != DBNull.Value) res.ErtefaSaqf = (float)dr["ErtefaSaqf"];
                if (dr["Hashie"] != DBNull.Value) res.Hashie = (float)dr["Hashie"];
                if (dr["Lenght"] != DBNull.Value) res.Lenght = (float)dr["Lenght"];
                if (dr["SaleSakht"] != DBNull.Value) res.SaleSakht = dr["SaleSakht"].ToString();
                if (dr["DateParvane"] != DBNull.Value) res.DateParvane = dr["DateParvane"].ToString();
                if (dr["ParvaneSerial"] != DBNull.Value) res.ParvaneSerial = dr["ParvaneSerial"].ToString();
                if (dr["BonBast"] != DBNull.Value) res.BonBast = (bool)dr["BonBast"];
                if (dr["MamarJoda"] != DBNull.Value) res.MamarJoda = (bool)dr["MamarJoda"];
                if (dr["RoomCount"] != DBNull.Value) res.RoomCount = (int)dr["RoomCount"];
                if (dr["CreateDate"] != DBNull.Value) res.CreateDate = (DateTime)dr["CreateDate"];
                if (dr["Image"] != DBNull.Value) res.Image = dr["Image"].ToString();
                if (dr["Priority"] != DBNull.Value) res.Priority = (EnBuildingPriority)dr["Priority"];
                if (dr["IsArchive"] != DBNull.Value) res.IsArchive = (bool)dr["IsArchive"];
                if (isLoadDets)
                {
                    res.GalleryList = AsyncContext.Run(() => BuildingGalleryBussines.GetAllAsync(res.Guid));
                    res.MediaList = AsyncContext.Run(() => BuildingMediaBussines.GetAllAsync(res.Guid));
                    res.OptionList = BuildingRelatedOptionsBussines.GetAll(res.Guid);
                }
                if (dr["ServerDeliveryDate"] != DBNull.Value) res.ServerDeliveryDate = (DateTime)dr["ServerDeliveryDate"];
                if (dr["ServerStatus"] != DBNull.Value) res.ServerStatus = (ServerStatus)dr["ServerStatus"];
                if (dr["OwnerName"] != DBNull.Value) res.OwnerName = dr["OwnerName"].ToString();
                if (dr["BuildingTypeName"] != DBNull.Value) res.BuildingTypeName = dr["BuildingTypeName"].ToString();
                if (dr["UserName"] != DBNull.Value) res.UserName = dr["UserName"].ToString();
                if (dr["RegionName"] != DBNull.Value) res.RegionName = dr["RegionName"].ToString();
                if (dr["RentalAuthorityName"] != DBNull.Value) res.RentalAuthorityName = dr["RentalAuthorityName"].ToString();
                if (dr["DocumentTypeName"] != DBNull.Value) res.DocumentTypeName = dr["DocumentTypeName"].ToString();
                if (dr["BuildingConditionName"] != DBNull.Value) res.BuildingConditionName = dr["BuildingConditionName"].ToString();
                if (dr["BuildingViewName"] != DBNull.Value) res.BuildingViewName = dr["BuildingViewName"].ToString();
                if (dr["FloorCoverName"] != DBNull.Value) res.FloorCoverName = dr["FloorCoverName"].ToString();
                if (dr["KitchenServiceName"] != DBNull.Value) res.KitchenServiceName = dr["KitchenServiceName"].ToString();
                if (dr["BuildingAccountTypeName"] != DBNull.Value) res.BuildingAccountTypeName = dr["BuildingAccountTypeName"].ToString();
                res.IsModified = true;
                if (dr["TelegramCount"] != DBNull.Value) res.TelegramCount = (int)dr["TelegramCount"];
                if (dr["DivarCount"] != DBNull.Value) res.DivarCount = (int)dr["DivarCount"];
                if (dr["SheypoorCount"] != DBNull.Value) res.SheypoorCount = (int)dr["SheypoorCount"];
                if (dr["AdvertiseType"] != DBNull.Value) res.AdvertiseType = (AdvertiseType)dr["AdvertiseType"];
                if (dr["DivarTitle"] != DBNull.Value) res.DivarTitle = dr["DivarTitle"].ToString();
                if (dr["Hiting"] != DBNull.Value) res.Hiting = dr["Hiting"].ToString();
                if (dr["Colling"] != DBNull.Value) res.Colling = dr["Colling"].ToString();
                if (dr["WhatsAppCount"] != DBNull.Value) res.WhatsAppCount = (int)dr["WhatsAppCount"];
                if (dr["Tabdil"] != DBNull.Value) res.Tabdil = (bool)dr["Tabdil"];
                if (dr["ReformArea"] != DBNull.Value) res.ReformArea = (float)dr["ReformArea"];
                if (dr["BuildingPermits"] != DBNull.Value) res.BuildingPermits = (bool)dr["BuildingPermits"];
                if (dr["WidthOfPassage"] != DBNull.Value) res.WidthOfPassage = (float)dr["WidthOfPassage"];
                if (dr["VillaType"] != DBNull.Value) res.VillaType = (EnVillaType)dr["VillaType"];
                if (dr["CommericallLicense"] != DBNull.Value) res.CommericallLicense = (EnCommericallLicense)dr["CommericallLicense"];
                if (dr["SuitableFor"] != DBNull.Value) res.SuitableFor = dr["SuitableFor"].ToString();
                if (dr["WallCovering"] != DBNull.Value) res.WallCovering = dr["WallCovering"].ToString();
                if (dr["TreeCount"] != DBNull.Value) res.TreeCount = (int)dr["TreeCount"];
                if (dr["ConstructionStage"] != DBNull.Value) res.ConstructionStage = (EnConstructionStage)dr["ConstructionStage"];
                if (dr["Parent"] != DBNull.Value) res.Parent = (EnBuildingParent)dr["Parent"];
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
