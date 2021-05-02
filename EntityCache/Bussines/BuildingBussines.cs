using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.ViewModels;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingBussines : IBuilding
    {
        #region Properties
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
        public string OwnerName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public int Dang { get; set; }
        public Guid? DocumentType { get; set; }
        public string DocumentTypeName { get; set; }
        public EnTarakom? Tarakom { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public string RentalAuthorityName { get; set; }
        public bool? IsShortTime { get; set; }
        public bool? IsOwnerHere { get; set; }
        public decimal PishTotalPrice { get; set; }
        public decimal PishPrice { get; set; }
        public DateTime? DeliveryDate { get; set; } = DateTime.Now;
        public string PishDesc { get; set; }
        public string MoavezeDesc { get; set; }
        public string MosharekatDesc { get; set; }
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        public Guid CityGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string RegionName { get; set; }
        public string Address { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public string BuildingConditionName { get; set; }
        public EnBuildingSide Side { get; set; }
        public string SideName => Side.GetDisplay();
        public Guid BuildingTypeGuid { get; set; }
        public string BuildingTypeName { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public string BuildingAccountTypeName { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid BuildingViewGuid { get; set; }
        public string BuildingViewName { get; set; }
        public Guid FloorCoverGuid { get; set; }
        public string FloorCoverName { get; set; }
        public Guid KitchenServiceGuid { get; set; }
        public string KitchenServiceName { get; set; }
        public EnKhadamati Water { get; set; }
        public string WaterName => Water.GetDisplay();
        public EnKhadamati Barq { get; set; }
        public string BarqName => Barq.GetDisplay();
        public EnKhadamati Gas { get; set; }
        public string GasName => Gas.GetDisplay();
        public EnKhadamati Tell { get; set; }
        public string TellName => Tell.GetDisplay();
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public float MetrazhKouche { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        public string SaleSakht { get; set; }
        public string DateParvane { get; set; }
        public string ParvaneSerial { get; set; }
        public bool BonBast { get; set; }
        public bool MamarJoda { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public string HardSerial => Cache.HardSerial;
        public string Image { get; set; }
        public bool IsModified { get; set; } = false;
        public List<BuildingRelatedOptionsBussines> OptionList { get; set; }
        public List<BuildingGalleryBussines> GalleryList { get; set; }
        #endregion

        public static async Task<List<BuildingBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Building.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<BuildingBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetAsync(Cache.ConnectionString, guid);
        public static BuildingBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }

                if (OptionList.Count > 0)
                {
                    res.AddReturnedValue(await BuildingRelatedOptionsBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in OptionList)
                        item.BuildinGuid = Guid;
                    res.AddReturnedValue(await BuildingRelatedOptionsBussines.SaveRangeAsync(OptionList, tr));
                    if (res.HasError) return res;
                }
                if (GalleryList.Count > 0)
                {
                    res.AddReturnedValue(await BuildingGalleryBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in GalleryList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingGalleryBussines.SaveRangeAsync(GalleryList, tr));
                    if (res.HasError) return res;
                }


                res.AddReturnedValue(await UnitOfWork.Building.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuilding.SaveAsync(this, Cache.Path));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, SqlTransaction tr = null)
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = tr == null;
            SqlConnection cn = null;
            try
            {
                if (autoTran)
                {
                    cn = new SqlConnection(Cache.ConnectionString);
                    await cn.OpenAsync();
                    tr = cn.BeginTransaction();
                }


                res.AddReturnedValue(await UnitOfWork.Building.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuilding.SaveAsync(this, Cache.Path));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (autoTran)
                {
                    res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                    res.AddReturnedValue(cn.CloseConnection());
                }
            }
            return res;
        }
        public static List<BuildingBussines> GetAll(string search, CancellationToken token, bool? isArchive, bool status,
            Guid buildingTypeGuid, Guid userGuid, Guid docTypeGuid, Guid accTypeGuid) => AsyncContext.Run(() =>
            GetAllAsync(search, token, isArchive, status, buildingTypeGuid, userGuid, docTypeGuid, accTypeGuid));
        public static async Task<List<BuildingBussines>> GetAllAsync(string search, CancellationToken token, bool? isArchive, bool status,
            Guid buildingTypeGuid, Guid userGuid, Guid docTypeGuid, Guid accTypeGuid)
        {
            try
            {
                IEnumerable<BuildingBussines> res;
                if (string.IsNullOrEmpty(search)) search = "";
                res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                if (res == null || !res.Any()) return res?.ToList();

                res = res.Where(q => q.Status == status);
                if (token.IsCancellationRequested) return null;
                if (isArchive != null) res = res.Where(q => q.IsArchive == isArchive);
                if (token.IsCancellationRequested) return null;
                if (buildingTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingTypeGuid == buildingTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (userGuid != Guid.Empty)
                    res = res.Where(q => q.UserGuid == userGuid).ToList();
                if (token.IsCancellationRequested) return null;
                if (docTypeGuid != Guid.Empty)
                    res = res.Where(q => q.DocumentType != null && q.DocumentType.Value == docTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (accTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingAccountTypeGuid == accTypeGuid);
                if (token.IsCancellationRequested) return null;

                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.OwnerName.ToLower().Contains(item.ToLower()) ||
                                                 x.BuildingTypeName.ToLower().Contains(item.ToLower()) ||
                                                 x.Masahat.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.ZirBana.ToString().ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.Address.ToLower().Contains(item.ToLower()) ||
                                                 x.RegionName.ToLower().Contains(item.ToLower()));
                        }
                    }

                return res?.ToList();
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingBussines>();
            }
        }
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Building.NextCodeAsync(Cache.ConnectionString);
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Building.CheckCodeAsync(Cache.ConnectionString, code, guid);
        public static async Task<List<BuildingViewModel>> GetAllAsync(string code, CancellationToken token, Guid buildingGuid,
            Guid buildingAccountTypeGuid, int fMasahat, int lMasahat, int roomCount, decimal fPrice1, decimal lPrice1,
            decimal fPrice2, decimal lPrice2, EnRequestType type, List<Guid> regionList)
        {
            try
            {
                IEnumerable<BuildingBussines> res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                if (regionList.Count > 0) res = res.Where(q => regionList.Contains(q.RegionGuid));
                if (token.IsCancellationRequested) return null;
                if (!string.IsNullOrEmpty(code)) res = res.Where(q => q.Code.Contains(code));
                if (token.IsCancellationRequested) return null;
                if (buildingGuid != Guid.Empty) res = res.Where(q => q.BuildingTypeGuid == buildingGuid);
                if (token.IsCancellationRequested) return null;
                if (buildingAccountTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingAccountTypeGuid == buildingAccountTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (fMasahat != 0) res = res.Where(q => q.Masahat >= fMasahat);
                if (token.IsCancellationRequested) return null;
                if (lMasahat != 0) res = res.Where(q => q.Masahat <= lMasahat);
                if (token.IsCancellationRequested) return null;
                if (roomCount != 0) res = res.Where(q => q.RoomCount <= roomCount);
                if (token.IsCancellationRequested) return null;
                if (type == EnRequestType.Rahn)
                {
                    if (token.IsCancellationRequested) return null;
                    if (fPrice1 != 0) res = res.Where(q => q.RahnPrice1 >= fPrice1);
                    if (fPrice2 != 0) res = res.Where(q => q.RahnPrice2 <= fPrice2);
                    if (token.IsCancellationRequested) return null;
                    if (lPrice1 != 0) res = res.Where(q => q.EjarePrice1 >= lPrice1);
                    if (lPrice2 != 0) res = res.Where(q => q.EjarePrice2 <= lPrice2);
                }
                else
                {
                    if (token.IsCancellationRequested) return null;
                    if (fPrice1 != 0) res = res.Where(q => q.SellPrice > 0 && q.SellPrice >= fPrice1);
                    if (fPrice2 != 0) res = res.Where(q => q.SellPrice > 0 && q.SellPrice <= fPrice2);
                }
                if (token.IsCancellationRequested) return null;
                var val = new List<BuildingViewModel>();

                foreach (var item in res)
                {
                    if (token.IsCancellationRequested) return null;
                    var a = new BuildingViewModel()
                    {
                        RoomCount = item.RoomCount.ToString(),
                        SaleSakht = item.SaleSakht,
                        Tabaqe = $"{item.TabaqeNo} از {item.TedadTabaqe}",
                        Description = item.ShortDesc,
                        Metrazh = item.Masahat,
                        Region = item.RegionName,
                        RentalAuthority = item.RentalAuthorityName,
                        Parent = $"فایل های سیستم کد {item.Code}",
                        Options = item.OptionList.Select(q => q.OptionName).ToList(),
                        Address = item.Address,
                        Mobile = PeoplesBussines.Get(item.OwnerGuid).FirstNumber
                    };
                    if (token.IsCancellationRequested) return null;
                    if (type == EnRequestType.Rahn)
                    {
                        a.Price1 = item.RahnPrice1;
                        a.Price2 = item.EjarePrice1;
                        if (item.RahnPrice2 != 0) a.Tabdil = item.RahnPrice2 + "ریال ودیعه";
                        if (item.EjarePrice2 != 0) a.Tabdil = a.Tabdil + item.EjarePrice2 + "ریال ودیعه";
                        if (item.RahnPrice2 == 0 && item.EjarePrice2 == 0) a.Tabdil = "غیرقابل تبدیل";
                        a.Type = EnRequestType.Rahn;
                    }
                    else
                    {
                        if (token.IsCancellationRequested) return null;
                        a.Price1 = item.SellPrice;
                        a.Price2 = 0;
                        a.Type = EnRequestType.Forush;
                    }
                    val.Add(a);
                }

                return val;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingViewModel>();
            }
        }
        public static async Task<int> DbCount(Guid userGuid, short type) =>
            await UnitOfWork.Building.DbCount(Cache.ConnectionString, userGuid, type);
        public static async Task<ReturnedSaveFuncInfo> FixImageAsync() => await UnitOfWork.Building.FixImageAsync(Cache.ConnectionString);
    }
}
