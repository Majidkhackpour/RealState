using EntityCache.Assistence;
using EntityCache.Mppings;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        public Guid? ZoncanGuid { get; set; }
        public Guid? WindowGuid { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(CreateDate);
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public int Dang { get; set; }
        public Guid? DocumentType { get; set; }
        public EnTarakom? Tarakom { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public bool? Tabdil { get; set; }
        public bool? IsShortTime { get; set; }
        public bool? IsOwnerHere { get; set; }
        public decimal PishTotalPrice { get; set; }
        public decimal PishPrice { get; set; }
        public DateTime? DeliveryDate { get; set; } = DateTime.Now;
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        public Guid CityGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string Address { get; set; }
        public Guid? BuildingConditionGuid { get; set; }
        public EnBuildingSide? Side { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid? BuildingViewGuid { get; set; }
        public Guid? FloorCoverGuid { get; set; }
        public Guid? KitchenServiceGuid { get; set; }
        public EnKhadamati? Water { get; set; }
        public EnKhadamati? Barq { get; set; }
        public EnKhadamati? Gas { get; set; }
        public EnKhadamati? Tell { get; set; }
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public int VahedNo { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        public float Lenght { get; set; }
        public float ReformArea { get; set; }
        public bool? BuildingPermits { get; set; }
        public float WidthOfPassage { get; set; }
        public string SaleSakht { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        public string Image { get; set; }
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

        public static async Task<List<BuildingBussines>> GetAllWithoutParentAsync() => await UnitOfWork.Building.GetAllWithoutParentAsync(Cache.ConnectionString);
        public static async Task<BuildingBussines> GetAsync(Guid guid) => await UnitOfWork.Building.GetAsync(Cache.ConnectionString, guid);
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



                if (isAddLog)
                {
                    var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                    var desc = $"کد ملک:( {Code} ) ** آدرس:( {Address} )";
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, Guid, desc, tr));
                    if (res.HasError) return res;
                }

                if (isRaiseEvent) RaiseEvent();
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

                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(this));
            }
            return res;
        }
        public async Task<ReturnedSaveFuncInfo> ChangeStatusAsync(bool status, bool isRaiseEvent = true, SqlTransaction tr = null)
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

                ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await UnitOfWork.Building.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                if (isRaiseEvent)
                {
                    var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                    var desc = $"کدملک: ( {Code} )";
                    res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Building, Guid, desc, tr));
                    RaiseEvent();
                }
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
                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(this));
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

                ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await UnitOfWork.Building.ChangeParentAsync(Guid, parent, tr));
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
                if (!res.HasError && Cache.IsSendToServer)
                    _ = Task.Run(() => SendToServerAsync(this));
            }
            return res;
        }
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Building.NextCodeAsync(Cache.ConnectionString);
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
                var dayCount = SettingsBussines.Setting.Global.SetArchive;
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
        public static async Task<bool> CheckDuplicateAsync(string divarTitle) => await UnitOfWork.Building.CheckDuplicateAsync(Cache.ConnectionString, divarTitle);
        public static async Task<List<string>> GetAllHittingAsync() => await UnitOfWork.Building.GetAllHittingAsync(Cache.ConnectionString);
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
                bu.ServerStatus = ServerStatus.None;
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
        public async Task<int> CheckAsync() => await UnitOfWork.Building.CheckAsync(Cache.ConnectionString, this);
        public static async Task<List<BuildingBussines>> GetAllNotSentAsync()
            => await UnitOfWork.Building.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.Building.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = BuildingMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebBuilding.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingBussines item)
            => await SendToServerAsync(new List<BuildingBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.Building.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var list = await GetAllNotSentAsync();
                if (list == null || list.Count <= 0) return res;
                foreach (var item in list)
                    res.AddReturnedValue(await SendToServerAsync(item));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<List<Guid>> GetGuidListAsync() => await UnitOfWork.Building.GetBuildingGuidListAsync(Cache.ConnectionString);
    }
}
