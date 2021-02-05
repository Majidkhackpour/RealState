using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<BuildingRelatedOptionsBussines> _optionList;
        public List<BuildingRelatedOptionsBussines> OptionList
        {
            get
            {
                if (_optionList != null) return _optionList;
                _optionList = BuildingRelatedOptionsBussines.GetAll(Guid, Status);
                return _optionList;
            }
            set => _optionList = value;
        }
        private List<BuildingGalleryBussines> _galleryList;
        public List<BuildingGalleryBussines> GalleryList
        {
            get
            {
                if (_galleryList != null) return _galleryList;
                _galleryList = AsyncContext.Run(() => BuildingGalleryBussines.GetAllAsync(Guid, Status));
                return _galleryList;
            }
            set => _galleryList = value;
        }
        #endregion

        public static async Task<List<BuildingBussines>> GetAllAsync() => await UnitOfWork.Building.GetAllAsyncBySp();
        public static async Task<BuildingBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetAsync(guid);
        public static BuildingBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                if (OptionList.Count > 0)
                {
                    var list = await BuildingRelatedOptionsBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.BuildingRelatedOptions.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    if (res.HasError) return res;

                    foreach (var item in OptionList)
                        item.BuildinGuid = Guid;
                    res.AddReturnedValue(
                        await UnitOfWork.BuildingRelatedOptions.SaveRangeAsync(OptionList, tranName));
                    if (res.HasError) return res;
                }

                if (GalleryList.Count > 0)
                {
                    var list = await BuildingGalleryBussines.GetAllAsync(Guid, Status);
                    res.AddReturnedValue(
                        await UnitOfWork.BuildingGallery.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                            tranName));
                    if (res.HasError) return res;

                    foreach (var item in GalleryList)
                        item.BuildingGuid = Guid;
                    res.AddReturnedValue(
                        await UnitOfWork.BuildingGallery.SaveRangeAsync(GalleryList, tranName));
                    if (res.HasError) return res;
                }


                res.AddReturnedValue(await UnitOfWork.Building.SaveAsync(this, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuilding.SaveAsync(this, Cache.Path));
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }

                if (OptionList.Count > 0)
                {
                    foreach (var item in OptionList)
                    {
                        res.AddReturnedValue(
                            await item.ChangeStatusAsync(status, tranName));
                        if (res.HasError) return res;
                    }
                }

                if (GalleryList.Count > 0)
                {
                    foreach (var item in GalleryList)
                    {
                        res.AddReturnedValue(
                            await item.ChangeStatusAsync(status, tranName));
                        if (res.HasError) return res;
                    }
                }


                res.AddReturnedValue(await UnitOfWork.Building.ChangeStatusAsync(this, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }


                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuilding.SaveAsync(this, Cache.Path));
            }
            catch (Exception ex)
            {
                if (autoTran)
                {
                    //RollBackTransAction
                }
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static List<BuildingBussines> GetAll(string search, bool? isArchive, bool status,
            Guid buildingTypeGuid, Guid userGuid, Guid docTypeGuid, Guid accTypeGuid) => AsyncContext.Run(() =>
            GetAllAsync(search, isArchive, status, buildingTypeGuid, userGuid, docTypeGuid, accTypeGuid));
        public static async Task<List<BuildingBussines>> GetAllAsync(string search, bool? isArchive, bool status,
            Guid buildingTypeGuid, Guid userGuid, Guid docTypeGuid, Guid accTypeGuid)
        {
            try
            {
                IEnumerable<BuildingBussines> res;
                if (string.IsNullOrEmpty(search)) search = "";
                res = await GetAllAsync();
                if (res == null || !res.Any()) return res?.ToList();

                res = res.Where(q => q.Status == status);

                if (isArchive != null) res = res.Where(q => q.IsArchive == isArchive);

                if (buildingTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingTypeGuid == buildingTypeGuid);
                if (userGuid != Guid.Empty)
                    res = res.Where(q => q.UserGuid == userGuid).ToList();
                if (docTypeGuid != Guid.Empty)
                    res = res.Where(q => q.DocumentType != null && q.DocumentType.Value == docTypeGuid);
                if (accTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingAccountTypeGuid == accTypeGuid);

                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
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
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingBussines>();
            }
        }
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Building.NextCodeAsync();
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Building.CheckCodeAsync(code, guid);
        public static async Task<List<BuildingViewModel>> GetAllAsync(string code, Guid buildingGuid,
            Guid buildingAccountTypeGuid, int fMasahat, int lMasahat, int roomCount, decimal fPrice1, decimal lPrice1,
            decimal fPrice2, decimal lPrice2, EnRequestType type, List<Guid> regionList)
        {
            try
            {
                var res = await GetAllAsync();
                if (!string.IsNullOrEmpty(code)) res = res.Where(q => q.Code.Contains(code)).ToList();
                if (buildingGuid != Guid.Empty) res = res.Where(q => q.BuildingTypeGuid == buildingGuid).ToList();
                if (buildingAccountTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingAccountTypeGuid == buildingAccountTypeGuid).ToList();
                if (fMasahat != 0) res = res.Where(q => q.Masahat >= fMasahat).ToList();
                if (lMasahat != 0) res = res.Where(q => q.Masahat <= lMasahat).ToList();
                if (roomCount != 0) res = res.Where(q => q.RoomCount <= roomCount).ToList();
                if (type == EnRequestType.Rahn)
                {
                    if (fPrice1 != 0) res = res.Where(q => q.RahnPrice1 >= fPrice1).ToList();
                    if (fPrice2 != 0) res = res.Where(q => q.RahnPrice2 <= fPrice2).ToList();

                    if (lPrice1 != 0) res = res.Where(q => q.EjarePrice1 >= lPrice1).ToList();
                    if (lPrice2 != 0) res = res.Where(q => q.EjarePrice2 <= lPrice2).ToList();
                }
                else
                {
                    if (fPrice1 != 0) res = res.Where(q => q.SellPrice >= fPrice1).ToList();
                    if (fPrice2 != 0) res = res.Where(q => q.SellPrice <= fPrice2).ToList();
                }

                if (regionList.Count > 0) res = res.Where(q => regionList.Contains(q.RegionGuid)).ToList();

                var val = new List<BuildingViewModel>();

                foreach (var item in res)
                {
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
                        a.Price1 = item.SellPrice;
                        a.Price2 = 0;
                        a.Type = EnRequestType.Forush;
                    }
                    val.Add(a);
                }

                return val;
            }
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingViewModel>();
            }
        }
        public static async Task<int> DbCount(Guid userGuid, short type) =>
            await UnitOfWork.Building.DbCount(userGuid, type);
    }
}
