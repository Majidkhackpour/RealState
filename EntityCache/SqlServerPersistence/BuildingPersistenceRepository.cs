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

        public async Task<List<BuildingBussines>> GetAllAsyncBySp()
        {
            try
            {
                var res = db.Database.SqlQuery<BuildingBussines>("sp_Buildings_SelectAll");
                var a = await res.ToListAsync();
                return a;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
        public async Task<string> NextCodeAsync()
        {
            try
            {
                var all = await GetAllAsync();
                if (all.Count <= 0) return "001001";
                var code = all.ToList()?.Max(q => long.Parse(q.Code)) ?? 0;
                code += 1;
                var new_code = code.ToString();
                if (code < 10)
                {
                    new_code = "00000" + code;
                    return new_code;
                }
                if (code >= 10 && code < 100)
                {
                    new_code = "0000" + code;
                    return new_code;
                }
                if (code >= 100 && code < 1000)
                {
                    new_code = "000" + code;
                    return new_code;
                }

                if (code >= 1000 && code < 10000)
                {
                    new_code = "00" + code;
                    return new_code;
                }
                if (code >= 10000 && code < 100000)
                {
                    new_code = "0" + code;
                    return new_code;
                }
                if (code >= 100000 && code < 1000000)
                {
                    new_code = code.ToString();
                    return new_code;
                }

                return new_code;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
                return "001001";
            }
        }
        public async Task<bool> CheckCodeAsync(string code, Guid guid)
        {
            try
            {
                var acc = db.Building.AsNoTracking()
                    .Where(q => q.Code == code.Trim() && q.Guid != guid)
                    .ToList();
                return acc.Count == 0;
            }
            catch (Exception exception)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(exception);
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
