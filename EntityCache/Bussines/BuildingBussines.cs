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
        public Guid? BuildingConditionGuid { get; set; }
        public string BuildingConditionName { get; set; }
        public EnBuildingSide? Side { get; set; }
        public string SideName => Side?.GetDisplay();
        public Guid BuildingTypeGuid { get; set; }
        public string BuildingTypeName { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public string BuildingAccountTypeName { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid? BuildingViewGuid { get; set; }
        public string BuildingViewName { get; set; }
        public Guid? FloorCoverGuid { get; set; }
        public string FloorCoverName { get; set; }
        public Guid? KitchenServiceGuid { get; set; }
        public string KitchenServiceName { get; set; }
        public EnKhadamati? Water { get; set; }
        public string WaterName => Water?.GetDisplay();
        public EnKhadamati? Barq { get; set; }
        public string BarqName => Barq?.GetDisplay();
        public EnKhadamati? Gas { get; set; }
        public string GasName => Gas?.GetDisplay();
        public EnKhadamati? Tell { get; set; }
        public string TellName => Tell?.GetDisplay();
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
        public List<BuildingNoteBussines> NoteList { get; set; }
        #endregion

        public static async Task<List<BuildingBussines>> GetAllAsync(CancellationToken token, bool isLoadDet) => await UnitOfWork.Building.GetAllAsync(Cache.ConnectionString, token, isLoadDet);
        public static async Task<BuildingBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetAsync(Cache.ConnectionString, guid);
        public static BuildingBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool isAddLog, SqlTransaction tr = null, bool isRaiseEvent = true, bool isFromServer = false)
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

                res.AddReturnedValue(await BuildingRelatedOptionsBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingGalleryBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingMediaBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await BuildingNoteBussines.RemoveRangeAsync(Guid, tr));
                if (res.HasError) return res;

                if (OptionList?.Count > 0)
                {
                    foreach (var item in OptionList)
                        item.BuildinGuid = Guid;
                    res.AddReturnedValue(await BuildingRelatedOptionsBussines.SaveRangeAsync(OptionList, tr));
                    if (res.HasError) return res;
                }
                if (GalleryList?.Count > 0)
                {
                    foreach (var item in GalleryList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingGalleryBussines.SaveRangeAsync(GalleryList, tr));
                    if (res.HasError) return res;
                }
                if (MediaList?.Count > 0)
                {
                    foreach (var item in MediaList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingMediaBussines.SaveRangeAsync(MediaList, tr));
                    if (res.HasError) return res;
                }
                if (NoteList?.Count > 0)
                {
                    foreach (var item in NoteList)
                        item.BuildingGuid = Guid;

                    res.AddReturnedValue(await BuildingNoteBussines.SaveRangeAsync(NoteList, tr));
                    if (res.HasError) return res;
                }

                if (isAddLog)
                {
                    var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, tr, Guid));
                    if (res.HasError) return res;
                }

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
        public async Task<ReturnedSaveFuncInfo> ChangeParentAsync(EnBuildingParent parent, SqlTransaction tr = null)
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


                res.AddReturnedValue(await UnitOfWork.Building.ChangeParentAsync(Guid, parent, tr));
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
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Building.NextCodeAsync(Cache.ConnectionString);
        public static string NextCode() => AsyncContext.Run(NextCodeAsync);
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Building.CheckCodeAsync(Cache.ConnectionString, code, guid);
        public static async Task<int> DbCount(Guid userGuid, short type) =>
            await UnitOfWork.Building.DbCount(Cache.ConnectionString, userGuid, type);
        public static async Task<ReturnedSaveFuncInfo> FixImageAsync() => await UnitOfWork.Building.FixImageAsync(Cache.ConnectionString);
        public async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(Code)) res.AddError("کد ملک نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Code.Trim(), Guid)) res.AddError("کد ملک وارد شده تکراری است");
                if (OwnerGuid == Guid.Empty) res.AddError("لطفا مالک را انتخاب نمایید");
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
                res.AddReturnedValue(await bu.SaveAsync(true, tr, false, true));
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
        public static async Task<List<BuildingBussines>> GetAllWithoutParentAsync() => await UnitOfWork.Building.GetAllWithoutParentAsync(Cache.ConnectionString);
        public async Task<int> CheckAsync() => await UnitOfWork.Building.CheckAsync(Cache.ConnectionString, this);
    }
}
