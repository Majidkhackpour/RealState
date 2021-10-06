using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using EntityCache.ViewModels;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.FilterObjects;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingBussines : IBuilding
    {
        public static event Func<Task> OnSaved;
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
        public decimal EjarePrice1 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public bool? Tabdil { get; set; }
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
        public float Lenght { get; set; }
        public float ReformArea { get; set; }
        public bool? BuildingPermits { get; set; }
        public float WidthOfPassage { get; set; }
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
        public int TelegramCount { get; set; }
        public int WhatsAppCount { get; set; }
        public int DivarCount { get; set; }
        public int SheypoorCount { get; set; }
        public AdvertiseType? AdvertiseType { get; set; } = null;
        public string DivarTitle { get; set; } = "";
        public string Hiting { get; set; }
        public string Colling { get; set; }
        public EnVillaType? VillaType { get; set; }
        public EnCommericallLicense? CommericallLicense { get; set; }
        public string SuitableFor { get; set; }
        public string WallCovering { get; set; }
        public int TreeCount { get; set; }
        public EnConstructionStage? ConstructionStage { get; set; }
        public EnBuildingParent? Parent { get; set; }
        public bool IsModified { get; set; } = false;
        public List<BuildingRelatedOptionsBussines> OptionList { get; set; }
        public List<BuildingGalleryBussines> GalleryList { get; set; }
        public List<BuildingMediaBussines> MediaList { get; set; }
        #endregion

        public static async Task<List<BuildingBussines>> GetAllAsync(CancellationToken token, bool isLoadDet) => await UnitOfWork.Building.GetAllAsync(Cache.ConnectionString, token, isLoadDet);
        public static async Task<BuildingBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetAsync(Cache.ConnectionString, guid);
        public static BuildingBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(SqlTransaction tr = null, bool isRaiseEvent = true, bool isFromServer = false)
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

                if (!isFromServer)
                {
                    res.AddReturnedValue(await CheckValidationAsync());
                    if (res.HasError) return res;
                }

                if (GalleryList?.Count > 0)
                    if (string.IsNullOrEmpty(Image))
                        Image = GalleryList?.FirstOrDefault()?.ImageName;

                res.AddReturnedValue(await UnitOfWork.Building.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (OptionList?.Count > 0)
                {
                    res.AddReturnedValue(await BuildingRelatedOptionsBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in OptionList)
                        item.BuildinGuid = Guid;
                    res.AddReturnedValue(await BuildingRelatedOptionsBussines.SaveRangeAsync(OptionList, tr));
                    if (res.HasError) return res;
                }
                if (GalleryList?.Count > 0)
                {
                    res.AddReturnedValue(await BuildingGalleryBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in GalleryList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingGalleryBussines.SaveRangeAsync(GalleryList, tr));
                    if (res.HasError) return res;
                }
                if (MediaList?.Count > 0)
                {
                    res.AddReturnedValue(await BuildingMediaBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in MediaList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingMediaBussines.SaveRangeAsync(MediaList, tr));
                    if (res.HasError) return res;
                }

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, tr));
                if (res.HasError) return res;
                if (isRaiseEvent) RaiseEvent();
                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuilding.SaveAsync(BuildingMapper.Instance.Map(this)));
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
                    _ = Task.Run(() => WebBuilding.SaveAsync(BuildingMapper.Instance.Map(this)));
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
        public static List<BuildingBussines> GetAll(BuildingFilter filters, bool isLoadDets, CancellationToken token) => AsyncContext.Run(() => GetAllAsync(filters, isLoadDets, token));
        public static async Task<List<BuildingBussines>> GetAllAsync(BuildingFilter filters, bool isLoadDets, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(filters.Search)) filters.Search = "";
                IEnumerable<BuildingBussines> res = await GetAllAsync(token, isLoadDets);
                if (token.IsCancellationRequested) return null;
                if (res == null || !res.Any()) return res?.ToList();
                if (filters.IsOnlyMine) res = res?.Where(q => q.AdvertiseType == null);
                if (filters.IsRahn) res = res?.Where(q => q.RahnPrice1 > 0);
                if (filters.IsSell) res = res?.Where(q => q.SellPrice > 0);
                if (filters.IsMosharekat) res = res?.Where(q => !string.IsNullOrEmpty(q.MosharekatDesc));
                if (filters.IsPishForoush) res = res?.Where(q => !string.IsNullOrEmpty(q.PishDesc) || q.PishPrice > 0);
                if (token.IsCancellationRequested) return null;
                res = res.Where(q => q.Status == filters.Status);
                if (token.IsCancellationRequested) return null;
                if (filters.OwnerGuid != Guid.Empty)
                    res = res.Where(q => q.OwnerGuid == filters.OwnerGuid);
                if (token.IsCancellationRequested) return null;
                if (filters.IsArchive != null) res = res.Where(q => q.IsArchive == filters.IsArchive);
                if (token.IsCancellationRequested) return null;
                if (filters.BuildingTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingTypeGuid == filters.BuildingTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (filters.UserGuid != Guid.Empty)
                    res = res.Where(q => q.UserGuid == filters.UserGuid);
                if (token.IsCancellationRequested) return null;
                if (filters.DocumentTypeGuid != Guid.Empty)
                    res = res.Where(q => q.DocumentType != null && q.DocumentType.Value == filters.DocumentTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (filters.BuildingAccountTypeGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingAccountTypeGuid == filters.BuildingAccountTypeGuid);
                if (token.IsCancellationRequested) return null;

                if (filters.RegionList != null && filters.RegionList.Count > 0)
                    res = res?.Where(q => filters.RegionList.Contains(q.RegionGuid));

                var searchItems = filters.Search.SplitString();
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
        public static string NextCode() => AsyncContext.Run(NextCodeAsync);
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Building.CheckCodeAsync(Cache.ConnectionString, code, guid);
        public static async Task<List<BuildingViewModel>> GetAllAsync(BuildingMatchFilter filter, CancellationToken token)
        {
            try
            {
                IEnumerable<BuildingBussines> res = await GetAllAsync(token, true);
                if (token.IsCancellationRequested) return null;
                if (filter.RegionList != null && filter.RegionList.Count > 0) res = res.Where(q => filter.RegionList.Contains(q.RegionGuid));
                if (token.IsCancellationRequested) return null;
                if (!string.IsNullOrEmpty(filter.BuildingCode)) res = res.Where(q => q.Code.Contains(filter.BuildingCode));
                if (token.IsCancellationRequested) return null;
                if (filter.BuildingTypeGuid != Guid.Empty) res = res.Where(q => q.BuildingTypeGuid == filter.BuildingTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (filter.BuildingAccountTypeGuid != Guid.Empty && filter.BuildingAccountTypeGuid != BuildingAccountTypeBussines.DefaultGuid)
                    res = res.Where(q => q.BuildingAccountTypeGuid == filter.BuildingAccountTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (filter.Masahat1 != 0) res = res.Where(q => q.Masahat >= filter.Masahat1);
                if (token.IsCancellationRequested) return null;
                if (filter.Masahat2 != 0) res = res.Where(q => q.Masahat <= filter.Masahat2);
                if (token.IsCancellationRequested) return null;
                if (filter.RoomCount != 0) res = res.Where(q => q.RoomCount <= filter.RoomCount);
                if (token.IsCancellationRequested) return null;
                if (filter.RequestType == EnRequestType.Rahn)
                {
                    if (token.IsCancellationRequested) return null;
                    if (filter.FirstPrice1 != 0) res = res.Where(q => q.RahnPrice1 >= filter.FirstPrice1);
                    if (filter.FirstPrice2 != 0) res = res.Where(q => q.RahnPrice1 <= filter.FirstPrice2);
                    if (token.IsCancellationRequested) return null;
                    if (filter.LastPrice1 != 0) res = res.Where(q => q.EjarePrice1 >= filter.LastPrice1);
                    if (filter.LastPrice2 != 0) res = res.Where(q => q.EjarePrice1 <= filter.LastPrice2);
                    res = res.Where(q => q.SellPrice <= 0);
                }
                else
                {
                    if (token.IsCancellationRequested) return null;
                    if (filter.FirstPrice1 != 0) res = res.Where(q => q.SellPrice > 0 && q.SellPrice >= filter.FirstPrice1);
                    if (filter.FirstPrice2 != 0) res = res.Where(q => q.SellPrice > 0 && q.SellPrice <= filter.FirstPrice2);
                }
                if (token.IsCancellationRequested) return null;
                var val = new List<BuildingViewModel>();
                res = res.OrderByDescending(q => q.CreateDate);
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
                        Parent = $"کد {item.Code}",
                        Options = item.OptionList.Select(q => q.OptionName)?.ToList(),
                        Address = item.Address,
                        Mobile = PeoplesBussines.Get(item.OwnerGuid, item.Guid)?.FirstNumber,
                        CreateDate = item.CreateDate,
                        Guid = item.Guid
                    };
                    if (token.IsCancellationRequested) return null;
                    if (item.AdvertiseType != null)
                        a.Parent += $" (دریافت شده)";
                    if (filter.RequestType == EnRequestType.Rahn)
                    {
                        a.Price1 = item.RahnPrice1;
                        a.Price2 = item.EjarePrice1;
                        if (item.RahnPrice1 != 0) a.Tabdil = item.RahnPrice1.ToString("N0") + " ودیعه";
                        if (item.EjarePrice1 != 0) a.Tabdil = $"{a.Tabdil} {item.EjarePrice1:N0} اجاره";
                        if (item.Tabdil != null && item.Tabdil == false) a.Tabdil = "غیرقابل تبدیل";
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
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(Code)) res.AddError("کد ملک نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Code.Trim(), Guid)) res.AddError("کد ملک وارد شده تکراری است");
                if (OwnerGuid == Guid.Empty) res.AddError("لطفا مالک را انتخاب نمایید");
                if (RahnPrice1 == 0 && EjarePrice1 == 0 && SellPrice == 0 && PishTotalPrice == 0)
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");

                if (ZirBana == 0 && Masahat == 0) res.AddError("لطفا مساحت و زیربنا را وارد نمایید");
                if (RegionGuid == Guid.Empty) res.AddError("لطفا محدوده ملک را وارد نمایید");
                if (TedadTabaqe < TabaqeNo) res.AddError($"تعداد طبقات ({TedadTabaqe}) نمی تواند از شماره طبقه ({TabaqeNo}) کوچکتر باشد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        private void RaiseEvent()
        {
            try
            {
                var handler = OnSaved;
                if (handler != null) OnSaved?.Invoke();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static void RaiseStaticEvent()
        {
            try
            {
                var handler = OnSaved;
                if (handler != null) OnSaved?.Invoke();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
        }
        public static async Task<ReturnedSaveFuncInfo> SetArchiveAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var dayCount = SettingsBussines.Get("DayCountForArchive")?.Value.ParseToInt() ?? 0;
                if (dayCount <= 0) dayCount = 60;
                var oldDate = DateTime.Now.AddDays(-dayCount);
                var date = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, 0, 0, 0);
                res.AddReturnedValue(await UnitOfWork.Building.SetArchiveAsync(Cache.ConnectionString, date));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<BuildingBussines>> GetAllHighPriorityAsync(CancellationToken token) => await UnitOfWork.Building.GetAllHighPriorityAsync(Cache.ConnectionString, token);
        public static async Task<bool> CheckDuplicateAsync(string divarTitle) => await UnitOfWork.Building.CheckDuplicateAsync(Cache.ConnectionString, divarTitle);
        public static async Task<List<string>> GetAllHittingAsync() => await UnitOfWork.Building.GetAllHittingAsync(Cache.ConnectionString);
        public static List<string> GetAllHitting() => AsyncContext.Run(GetAllHittingAsync);
        public static List<string> GetAllColling() => AsyncContext.Run(GetAllCollingAsync);
        public static async Task<List<string>> GetAllCollingAsync() => await UnitOfWork.Building.GetAllCollingAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SaveFromHostAsync(BuildingBussines bu, string number)
        {
            var res = new ReturnedSaveFuncInfo();
            SqlConnection cn = null;
            SqlTransaction tr = null;
            try
            {
                cn = new SqlConnection(Cache.ConnectionString);
                await cn.OpenAsync();
                tr = cn.BeginTransaction();

                var relatedNumber = new BuildingRelatedNumberBussines()
                {
                    Number = number,
                    BuildingGuid = bu.Guid
                };
                res.AddReturnedValue(await bu.SaveAsync(tr, false, true));
                if (res.HasError) return res;

                if (!string.IsNullOrEmpty(number))
                    res.AddReturnedValue(await relatedNumber.SaveAsync(tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                res.AddReturnedValue(tr.TransactionDestiny(res.HasError));
                res.AddReturnedValue(cn.CloseConnection());
            }
            return res;
        }
    }
}
