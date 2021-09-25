﻿using System;
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
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingOptionsBussines : IBuildingOptions
    {
        private static Guid _evelatorGuid = Guid.Empty;
        private static Guid _balconyGuid = Guid.Empty;
        private static Guid _parkingGuid = Guid.Empty;
        private static Guid _storeGuid = Guid.Empty;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public bool Checked { get; set; }
        public string HardSerial => Cache.HardSerial;
        public bool IsModified { get; set; } = false;
        public static Guid EveletorGuid
        {
            get
            {
                if (_evelatorGuid == Guid.Empty)
                    _evelatorGuid = AsyncContext.Run(GetEvelatorGuidAsync);
                return _evelatorGuid;
            }
        }
        public static Guid ParkingGuid
        {
            get
            {
                if (_parkingGuid == Guid.Empty)
                    _parkingGuid = AsyncContext.Run(GetParkingGuidAsync);
                return _parkingGuid;
            }
        }
        public static Guid BalconyGuid
        {
            get
            {
                if (_balconyGuid == Guid.Empty)
                    _balconyGuid = AsyncContext.Run(GetBalconyGuidAsync);
                return _balconyGuid;
            }
        }
        public static Guid StoreGuid
        {
            get
            {
                if (_storeGuid == Guid.Empty)
                    _storeGuid = AsyncContext.Run(GetStoreGuidAsync);
                return _storeGuid;
            }
        }


        public static async Task<List<BuildingOptionsBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.BuildingOption.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingOptionsBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingOption.SaveRangeAsync(list, tr));

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.MapList(list)));
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
        public static async Task<BuildingOptionsBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingOption.GetAsync(Cache.ConnectionString, guid);
        public static async Task<BuildingOptionsBussines> GetAsync(string name) => await UnitOfWork.BuildingOption.GetAsync(Cache.ConnectionString, name);
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

                res.AddReturnedValue(await CheckValidationAsync());
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.BuildingOption.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingOptions, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.Map(this)));
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

                res.AddReturnedValue(await UnitOfWork.BuildingOption.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingOptions, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebBuildingOptions.SaveAsync(BuildingOptionsMapper.Instance.Map(this)));
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
        public static async Task<List<BuildingOptionsBussines>> GetAllAsync(string search, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = await GetAllAsync(token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<BuildingOptionsBussines>();
            }
        }
        public static BuildingOptionsBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<bool> CheckNameAsync(string name, Guid guid) =>
            await UnitOfWork.BuildingOption.CheckNameAsync(Cache.ConnectionString, name, guid);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(Name)) res.AddError("عنوان نمی تواند خالی باشد");
                if (!await CheckNameAsync(Name.Trim(), Guid)) res.AddError("عنوان وارد شده تکراری است");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private static async Task<Guid> GetEvelatorGuidAsync()
        {
            try
            {
                var list = await GetAllAsync("سانسور", new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingOptionsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = "آسانسور",
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now
                };
                await def.SaveAsync();

                return def.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
        private static async Task<Guid> GetBalconyGuidAsync()
        {
            try
            {
                var list = await GetAllAsync("تراس", new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingOptionsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = "تراس",
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now
                };
                await def.SaveAsync();

                return def.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
        private static async Task<Guid> GetStoreGuidAsync()
        {
            try
            {
                var list = await GetAllAsync("انبار", new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingOptionsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = "انبار",
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now
                };
                await def.SaveAsync();

                return def.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
        private static async Task<Guid> GetParkingGuidAsync()
        {
            try
            {
                var list = await GetAllAsync("پارکینگ", new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingOptionsBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = "پارکینگ",
                    Status = true,
                    ServerStatus = ServerStatus.None,
                    ServerDeliveryDate = DateTime.Now
                };
                await def.SaveAsync();

                return def.Guid;
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return Guid.Empty;
            }
        }
    }
}
