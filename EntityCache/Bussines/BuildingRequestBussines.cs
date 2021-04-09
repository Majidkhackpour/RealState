using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingRequestBussines : IBuildingRequest
    {
        #region Properties
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
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
        public string HardSerial => Cache.HardSerial;
        private List<BuildingRequestRegionBussines> _regList;
        public List<BuildingRequestRegionBussines> RegionList
        {
            get
            {
                if (_regList != null) return _regList;
                _regList = AsyncContext.Run(() => BuildingRequestRegionBussines.GetAllAsync(Guid, Status));
                return _regList;
            }
            set => _regList = value;
        }
        #endregion

        public static async Task<List<BuildingRequestBussines>> GetAllAsync() => await UnitOfWork.BuildingRequest.GetAllAsync();
        public static async Task<BuildingRequestBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingRequest.GetAsync(guid);
        public static BuildingRequestBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                if (RegionList.Count > 0)
                {
                    res.AddReturnedValue(await BuildingRequestRegionBussines.RemoveRangeAsync(Guid, tranName));
                    if (res.HasError) return res;

                    foreach (var item in RegionList)
                        item.RequestGuid = Guid;
                    res.AddReturnedValue(await BuildingRequestRegionBussines.SaveRangeAsync(RegionList, tranName));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRequest.SaveAsync(this, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingRequest.SaveAsync(this));
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

                if (RegionList.Count > 0)
                {
                    res.AddReturnedValue(await BuildingRequestRegionBussines.ChangeStatusAsync(Guid, status, tranName));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.BuildingRequest.ChangeStatusAsync(this, status, tranName));
                if (res.HasError) return res;
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingRequest.SaveAsync(this));
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
        public static async Task<List<BuildingRequestBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync();

                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
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
            catch (OperationCanceledException)
            {
                return null;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingRequestBussines>();
            }
        }
        public static async Task<int> DbCount(Guid userGuid) => await UnitOfWork.BuildingRequest.DbCount(userGuid);
        public static async Task<List<BuildingRequestBussines>> GetAllAsync(EnRequestType type, decimal price1,
            decimal price2, int masahat,
            int roomCount, Guid accountTypeGuid, Guid conditionGuid, Guid regionGuid)
        {
            try
            {
                IEnumerable<BuildingRequestBussines> res = await GetAllAsync();

                if (type == EnRequestType.Forush)
                    res = res.Where(q => q.SellPrice1 <= price1 && q.SellPrice2 >= price1);
                else if (type == EnRequestType.Rahn)
                {
                    res = res.Where(q => q.RahnPrice1 <= price1 && q.RahnPrice2 >= price1);
                    if (price2 != 0) res = res.Where(q => q.EjarePrice1 <= price2 && q.EjarePrice2 >= price2);
                }

                if (masahat > 0) res = res.Where(q => q.Masahat1 <= masahat && q.Masahat2 >= masahat);
                if (roomCount > 0) res = res.Where(q => q.RoomCount <= roomCount);
                if (accountTypeGuid != Guid.Empty)
                    res = res.Where(q =>
                        q.BuildingAccountTypeGuid == Guid.Empty ||
                        q.BuildingAccountTypeGuid == accountTypeGuid);
                if (conditionGuid != Guid.Empty)
                    res = res.Where(q => q.BuildingConditionGuid == Guid.Empty ||
                                         q.BuildingConditionGuid == conditionGuid);
                if (regionGuid != Guid.Empty)
                    res = res.Where(q => q.RegionList.Select(p => p.RegionGuid).Contains(regionGuid));

                return res?.ToList();
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return null;
            }
        }
    }
}
