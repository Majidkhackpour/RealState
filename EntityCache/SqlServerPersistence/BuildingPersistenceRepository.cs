using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Bussines;
using EntityCache.Core;
using Nito.AsyncEx;
using Persistence.Entities;
using Persistence.Model;
using Services;

namespace EntityCache.SqlServerPersistence
{
    public class BuildingPersistenceRepository : GenericRepository<BuildingBussines, Building>, IBuildingRepository
    {
        private ModelContext db;
        private string _connectionString;
        public BuildingPersistenceRepository(ModelContext _db, string connectionString) : base(_db, connectionString)
        {
            db = _db;
            _connectionString = connectionString;
        }
        public override async Task<List<BuildingBussines>> GetAllAsync()
        {
            var list = new List<BuildingBussines>();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Buildings_SelectAll", cn) { CommandType = CommandType.StoredProcedure };

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
        public override async Task<ReturnedSaveFuncInfo> SaveAsync(BuildingBussines item, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_Save", cn) { CommandType = CommandType.StoredProcedure };
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
                    cmd.Parameters.AddWithValue("@rahnPrice2", item.RahnPrice2);
                    cmd.Parameters.AddWithValue("@ejarePrice1", item.EjarePrice1);
                    cmd.Parameters.AddWithValue("@ejarePrice2", item.EjarePrice2);
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
                    cmd.Parameters.AddWithValue("@side", (int)item.Side);
                    cmd.Parameters.AddWithValue("@typeGuid", item.BuildingTypeGuid);
                    cmd.Parameters.AddWithValue("@shortDesc", item.ShortDesc ?? "");
                    cmd.Parameters.AddWithValue("@accountTypeGuid", item.BuildingAccountTypeGuid);
                    cmd.Parameters.AddWithValue("@metrazhTejari", item.MetrazhTejari);
                    cmd.Parameters.AddWithValue("@viewGuid", item.BuildingViewGuid);
                    cmd.Parameters.AddWithValue("@floorCoverGuid", item.FloorCoverGuid);
                    cmd.Parameters.AddWithValue("@kitchenServiceGuid", item.KitchenServiceGuid);
                    cmd.Parameters.AddWithValue("@water", (short)item.Water);
                    cmd.Parameters.AddWithValue("@barq", (short)item.Barq);
                    cmd.Parameters.AddWithValue("@gas", (short)item.Gas);
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
        public override async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(BuildingBussines item, bool status, string tranName)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var cmd = new SqlCommand("sp_Building_ChangeStatus", cn) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@Guid", item.Guid);
                    cmd.Parameters.AddWithValue("@st", status);

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
        public async Task<string> NextCodeAsync()
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
        public async Task<bool> CheckCodeAsync(string code, Guid guid)
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
        public async Task<int> DbCount(Guid userGuid, short type)
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
        public async Task<ReturnedSaveFuncInfo> FixImageAsync()
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
        public override async Task<BuildingBussines> GetAsync(Guid guid)
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
        private BuildingBussines LoadData(SqlDataReader dr)
        {
            var res = new BuildingBussines();
            try
            {
                res.Guid = (Guid)dr["Guid"];
                res.OwnerGuid = (Guid)dr["OwnerGuid"];
                res.SellPrice = (decimal)dr["SellPrice"];
                res.Modified = (DateTime)dr["Modified"];
                res.Status = (bool)dr["Status"];
                res.Code = dr["Code"].ToString();
                res.VamPrice = (decimal)dr["VamPrice"];
                res.QestPrice = (decimal)dr["QestPrice"];
                res.Dang = (int)dr["Dang"];
                res.DocumentType = (Guid)dr["DocumentType"];
                var tr = dr["Tarakom"].ToString().ParseToShort();
                res.Tarakom = (EnTarakom?)tr;
                res.RahnPrice1 = (decimal)dr["RahnPrice1"];
                res.RahnPrice2 = (decimal)dr["RahnPrice2"];
                res.EjarePrice1 = (decimal)dr["EjarePrice1"];
                res.EjarePrice2 = (decimal)dr["EjarePrice2"];
                if (dr["RentalAutorityGuid"] != DBNull.Value) res.RentalAutorityGuid = (Guid?)dr["RentalAutorityGuid"];
                res.IsShortTime = (bool)dr["IsShortTime"];
                res.IsOwnerHere = (bool)dr["IsOwnerHere"];
                res.PishTotalPrice = (decimal)dr["PishTotalPrice"];
                res.PishPrice = (decimal)dr["PishPrice"];
                if (dr["DeliveryDate"] != DBNull.Value) res.DeliveryDate = (DateTime?)dr["DeliveryDate"];
                res.PishDesc = dr["PishDesc"].ToString();
                res.MoavezeDesc = dr["MoavezeDesc"].ToString();
                res.MosharekatDesc = dr["MosharekatDesc"].ToString();
                res.UserGuid = (Guid)dr["UserGuid"];
                res.Masahat = (int)dr["Masahat"];
                res.ZirBana = (int)dr["ZirBana"];
                res.CityGuid = (Guid)dr["CityGuid"];
                res.RegionGuid = (Guid)dr["RegionGuid"];
                res.Address = dr["Address"].ToString();
                res.BuildingConditionGuid = (Guid)dr["BuildingConditionGuid"];
                res.Side = (EnBuildingSide)dr["Side"];
                res.BuildingTypeGuid = (Guid)dr["BuildingTypeGuid"];
                res.ShortDesc = dr["ShortDesc"].ToString();
                res.BuildingAccountTypeGuid = (Guid)dr["BuildingAccountTypeGuid"];
                res.MetrazhTejari = (float)dr["MetrazhTejari"];
                res.BuildingViewGuid = (Guid)dr["BuildingViewGuid"];
                res.FloorCoverGuid = (Guid)dr["FloorCoverGuid"];
                res.KitchenServiceGuid = (Guid)dr["KitchenServiceGuid"];
                res.Water = (EnKhadamati)dr["Water"];
                res.Barq = (EnKhadamati)dr["Barq"];
                res.Gas = (EnKhadamati)dr["Gas"];
                res.Tell = (EnKhadamati)dr["Tell"];
                res.TedadTabaqe = (int)dr["TedadTabaqe"];
                res.TabaqeNo = (int)dr["TabaqeNo"];
                res.VahedPerTabaqe = (int)dr["VahedPerTabaqe"];
                res.MetrazhKouche = (float)dr["MetrazhKouche"];
                res.ErtefaSaqf = (float)dr["ErtefaSaqf"];
                res.Hashie = (float)dr["Hashie"];
                res.SaleSakht = dr["SaleSakht"].ToString();
                res.DateParvane = dr["DateParvane"].ToString();
                res.ParvaneSerial = dr["ParvaneSerial"].ToString();
                res.BonBast = (bool)dr["BonBast"];
                res.MamarJoda = (bool)dr["MamarJoda"];
                res.RoomCount = (int)dr["RoomCount"];
                res.CreateDate = (DateTime)dr["CreateDate"];
                res.Image = dr["Image"].ToString();
                res.Priority = (EnBuildingPriority)dr["Priority"];
                res.IsArchive = (bool)dr["IsArchive"];
                res.GalleryList = AsyncContext.Run(() => BuildingGalleryBussines.GetAllAsync(res.Guid, true));
                res.OptionList = BuildingRelatedOptionsBussines.GetAll(res.Guid, true);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }

            return res;
        }
    }
}
