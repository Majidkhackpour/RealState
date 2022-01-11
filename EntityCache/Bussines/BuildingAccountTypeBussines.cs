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
using Services.Interfaces;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class BuildingAccountTypeBussines : IBuildingAccountType
    {
        private static Guid _defGuid = Guid.Empty;

        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public bool IsModified { get; set; } = false;
        public static Guid DefaultGuid
        {
            get
            {
                if (_defGuid == Guid.Empty)
                    _defGuid = AsyncContext.Run(() => GetDefultGuidAsync("تعیین نشده"));
                return _defGuid;
            }
        }


        public static async Task<List<BuildingAccountTypeBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.BuildingAccountType.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<ReturnedSaveFuncInfo> SaveRangeAsync(List<BuildingAccountTypeBussines> list, SqlTransaction tr = null)
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

                res.AddReturnedValue(await UnitOfWork.BuildingAccountType.SaveRangeAsync(list, tr));
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
                    _ = Task.Run(() => SendToServerAsync(list));
            }
            return res;
        }
        public static async Task<BuildingAccountTypeBussines> GetAsync(Guid guid) => await UnitOfWork.BuildingAccountType.GetAsync(Cache.ConnectionString, guid);
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

                res.AddReturnedValue(await UnitOfWork.BuildingAccountType.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                var desc = $"عنوان کاربری ملک:( {Name} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingAccountType, Guid, desc, tr));
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

                res.AddReturnedValue(await UnitOfWork.BuildingAccountType.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                var desc = $"کاربری حذف شده:( {Name} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.BuildingAccountType, Guid, desc, tr));
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
        public static async Task<List<BuildingAccountTypeBussines>> GetAllAsync(string search, CancellationToken token)
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
                return new List<BuildingAccountTypeBussines>();
            }
        }
        public static List<BuildingAccountTypeBussines> GetAll(string search) => AsyncContext.Run(() => GetAllAsync(search, new CancellationToken()));
        public static BuildingAccountTypeBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<bool> CheckNameAsync(string name, Guid guid) =>
            await UnitOfWork.BuildingAccountType.CheckNameAsync(Cache.ConnectionString, name, guid);
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
        public static async Task<Guid> GetDefultGuidAsync(string name)
        {
            try
            {
                var list = await GetAllAsync(name, new CancellationToken());
                var def = list?.FirstOrDefault();
                if (def != null && def.Guid != Guid.Empty) return def.Guid;
                def = new BuildingAccountTypeBussines()
                {
                    Guid = Guid.NewGuid(),
                    Modified = DateTime.Now,
                    Name = name,
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
        public static async Task<List<BuildingAccountTypeBussines>> GetAllNotSentAsync()
            => await UnitOfWork.BuildingAccountType.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.BuildingAccountType.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<BuildingAccountTypeBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = BuildingAccountTypeMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebBuildingAccountType.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(BuildingAccountTypeBussines item)
            => await SendToServerAsync(new List<BuildingAccountTypeBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.BuildingAccountType.ResetAsync(Cache.ConnectionString);
    }
}
