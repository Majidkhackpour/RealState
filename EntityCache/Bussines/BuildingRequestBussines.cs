using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.FilterObjects;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingRequestBussines : IBuildingRequest
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
        public Guid AskerGuid { get; set; }
        public string AskerName { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellPrice2 { get; set; }
        public bool? HasVam { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public short? PeopleCount { get; set; }
        public bool? HasOwner { get; set; }
        public bool? ShortDate { get; set; }
        public Guid? RentalAutorityGuid { get; set; }
        public Guid CityGuid { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public int Masahat1 { get; set; }
        public int Masahat2 { get; set; }
        public int RoomCount { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public string ShortDesc { get; set; }
        public bool IsModified { get; set; } = false;
        public List<BuildingRequestRegionBussines> RegionList { get; set; }
        #endregion

        public static async Task<List<BuildingRequestBussines>> GetAllAsync(bool status, CancellationToken token) => await UnitOfWork.BuildingRequest.GetAllAsync(Cache.ConnectionString, status, token);
        public static async Task<BuildingRequestBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingRequest.GetAsync(Cache.ConnectionString, guid);
        public static BuildingRequestBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                res.AddReturnedValue(CheckValidation());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.BuildingRequest.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (RegionList.Count > 0)
                {
                    res.AddReturnedValue(await BuildingRequestRegionBussines.RemoveRangeAsync(Guid, tr));
                    if (res.HasError) return res;

                    foreach (var item in RegionList)
                        item.RequestGuid = Guid;
                    res.AddReturnedValue(await BuildingRequestRegionBussines.SaveRangeAsync(RegionList, tr));
                    if (res.HasError) return res;
                }

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                var desc = $"خواهان:( {AskerName} ) ** ";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingRequest, Guid, desc, tr));
                if (res.HasError) return res;
                RaiseEvent();
                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingRequest.SaveAsync(BuildingRequestMapper.Instance.Map(this)));
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

                res.AddReturnedValue(await UnitOfWork.BuildingRequest.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                var desc = $"خواهان:( {AskerName} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingRequest, Guid, desc, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingRequest.SaveAsync(BuildingRequestMapper.Instance.Map(this)));
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
        public static async Task<List<BuildingRequestBussines>> GetAllAsync(string search, bool status, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(status, token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.AskerName.ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.ShortDesc.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingRequestBussines>();
            }
        }
        public static async Task<int> DbCount(Guid userGuid) => await UnitOfWork.BuildingRequest.DbCount(Cache.ConnectionString, userGuid);
        public static async Task<List<BuildingRequestBussines>> GetAllAsync(RequestMatchFilter filter, CancellationToken token)
        {
            try
            {
                IEnumerable<BuildingRequestBussines> res = await GetAllAsync(true, token);
                if (token.IsCancellationRequested) return null;
                if (filter.Type == EnRequestType.Forush)
                    res = res.Where(q => q.SellPrice1 <= filter.Price1 && q.SellPrice2 >= filter.Price1);
                else if (filter.Type == EnRequestType.Rahn)
                {
                    if (token.IsCancellationRequested) return null;
                    res = res.Where(q => q.RahnPrice1 <= filter.Price1 && q.RahnPrice2 >= filter.Price1);
                    if (filter.Price2 != 0)
                        res = res.Where(q =>
                            (q.EjarePrice1 == 0 && q.EjarePrice2 == 0) ||
                            (q.EjarePrice1 <= filter.Price2 && q.EjarePrice2 >= filter.Price2));
                }
                if (token.IsCancellationRequested) return null;
                if (filter.Masahat > 0) res = res.Where(q => q.Masahat1 <= filter.Masahat && q.Masahat2 >= filter.Masahat);
                if (token.IsCancellationRequested) return null;
                if (filter.RoomCount > 0) res = res.Where(q => q.RoomCount <= filter.RoomCount);
                if (token.IsCancellationRequested) return null;
                if (filter.BuildingAccountTypeGuid != Guid.Empty)
                    res = res.Where(q =>
                        q.BuildingAccountTypeGuid == Guid.Empty ||
                        q.BuildingAccountTypeGuid == BuildingAccountTypeBussines.DefaultGuid ||
                        q.BuildingAccountTypeGuid == filter.BuildingAccountTypeGuid);
                if (token.IsCancellationRequested) return null;
                if (res == null) return null;
                if (filter.RegionGuid != Guid.Empty)
                    res = res.Where(q => q.RegionList == null || q.RegionList.Select(p => p.RegionGuid).Contains(filter.RegionGuid));
                return token.IsCancellationRequested ? null : res?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
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
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (AskerGuid == Guid.Empty) res.AddError("لطفا متقاضی را انتخاب نمایید");
                if (RahnPrice1 == 0 && RahnPrice2 == 0 && EjarePrice1 == 0 && EjarePrice2 == 0 && SellPrice1 == 0 && SellPrice2 == 0)
                    res.AddError("لطفا یکی از فیلدهای مبلغ را وارد نمایید");

                if (Masahat1 == 0 && Masahat2 == 0) res.AddError("لطفا مساحت را وارد نمایید");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> DeleteAfter60DaysAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var isDelete = SettingsBussines.Get("DeleteRequest")?.Value.ParseToBoolean() ?? false;
                if (!isDelete) return res;
                var oldDate = DateTime.Now.AddDays(-60);
                var date = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, 0, 0, 0);
                res.AddReturnedValue(await UnitOfWork.BuildingRequest.DeleteAsync(Cache.ConnectionString, date));
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
