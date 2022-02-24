using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using EntityCache.Mppings;
using Persistence;
using Services;
using Services.DefaultCoding;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class PeoplesBussines : IPeoples
    {
        private static Guid _defaultGuid = Guid.Empty;

        public static event Func<Task> OnSaved;
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Code { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string IdCode { get; set; }
        public string FatherName { get; set; }
        public string PlaceBirth { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public string IssuedFrom { get; set; }
        public string PostalCode { get; set; }
        public Guid GroupGuid { get; set; }
        public string GroupName { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string AccountType => Account.AccountDiagnosis();
        public string FirstNumber => TellList?.FirstOrDefault()?.Tell ?? "";
        public bool IsChecked { get; set; }
        public List<PhoneBookBussines> TellList { get; set; }
        public List<PeoplesBankAccountBussines> BankList { get; set; }
        public bool IsModified { get; set; } = false;
        public byte[] ServerStatusImage
        {
            get
            {
                if (ServerStatus == ServerStatus.Delivered || ServerStatus == ServerStatus.DirectDelivery)
                    return ImageResourceManager.ServerStatusDelivered;
                if (ServerStatus == ServerStatus.DeliveryError)
                    return ImageResourceManager.ServerStatusDeliveryFailed;
                if (ServerStatus == ServerStatus.Sent)
                    return ImageResourceManager.ServerStatusSent;
                if (ServerStatus == ServerStatus.SendError)
                    return ImageResourceManager.ServerStatusSentError;
                return ImageResourceManager.ServerStatusNone;
            }
        }


        public static async Task<List<PeoplesBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Peoples.GetAllAsync(Cache.ConnectionString, token);
        public static async Task<PeoplesBussines> GetAsync(Guid guid, Guid? buildingGuid)
        {
            PeoplesBussines pe = null;
            try
            {
                if (buildingGuid == null || buildingGuid == Guid.Empty)
                    pe = await UnitOfWork.Peoples.GetAsync(Cache.ConnectionString, guid);
                else
                    pe = await UnitOfWork.Peoples.GetByBuildingGuidAsync(Cache.ConnectionString, guid, buildingGuid.Value);
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
            }
            return pe;
        }
        public static async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status, CancellationToken token) =>
            await UnitOfWork.Peoples.GetAllAsync(Cache.ConnectionString, parentGuid, status, token);
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
               
                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                var desc = $"عنوان:( {Name} ) ** کد شخص:( {Code} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Peoples,Guid,desc, tr));
                if (res.HasError) return res;
                RaiseEvent();
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

                var tafsil = await TafsilBussines.GetAsync(Guid);
                if (tafsil == null)
                {
                    res.AddError("شخص انتخاب شده معتبر نمی باشد");
                    return res;
                }

                res.AddReturnedValue(await tafsil.ChangeStatusAsync(status, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PhoneBookBussines.ChangeStatusAsync(Guid, status, tr));
                if (res.HasError) return res;
                ServerStatus = ServerStatus.None;
                res.AddReturnedValue(await UnitOfWork.Peoples.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                var desc = $"عنوان:( {Name} ) ** کد شخص: ( {Code} )";
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Peoples,Guid,desc, tr));
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
        public static async Task<List<PeoplesBussines>> GetAllAsync(string search, Guid groupGuid, CancellationToken token)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                IEnumerable<PeoplesBussines> res;
                if (groupGuid == Guid.Empty) res = await GetAllAsync(token);
                else res = await GetAllAsync(groupGuid, true, token);
                if (token.IsCancellationRequested) return null;
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (token.IsCancellationRequested) return null;
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToLower().Contains(item.ToLower()) ||
                                                 x.Address.ToLower().Contains(item.ToLower()) ||
                                                 x.FatherName.ToLower().Contains(item.ToLower()) ||
                                                 x.NationalCode.ToLower().Contains(item.ToLower()) ||
                                                 x.GroupName.ToLower().Contains(item.ToLower()));
                        }
                    }

                res = res.OrderBy(q => q.Code);
                return res?.ToList();
            }
            catch (TaskCanceledException) { return null; }
            catch (OperationCanceledException) { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<PeoplesBussines>();
            }
        }
        public static async Task<List<PeoplesBussines>> GetAllBirthDayAsync(string dateSh) =>
            await UnitOfWork.Peoples.GetAllBirthDayAsync(Cache.ConnectionString, dateSh);
        public async Task<bool> CheckCodeAsync(Guid guid, string code) => await UnitOfWork.Tafsil.CheckCodeAsync(Cache.ConnectionString, guid, code);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان شخص نمی تواند خالی باشد");
                if (string.IsNullOrEmpty(Code)) res.AddError("کد شخص نمی تواند خالی باشد");
                if (!await CheckCodeAsync(Guid, Code)) res.AddError("کد شخص معتبر نمی باشد");
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
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
        public static async Task<PeoplesBussines> GetDefaultPeopleAsync() => await GetAsync(ParentDefaults.TafsilCoding.DefualtCustomer, null);
        public static async Task<List<PeoplesBussines>> GetAllNotSentAsync()
            => await UnitOfWork.Peoples.GetAllNotSentAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> SetSaveResultAsync(Guid guid, ServerStatus status)
            => await UnitOfWork.Peoples.SetSaveResultAsync(Cache.ConnectionString, guid, status);
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(List<PeoplesBussines> list)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                foreach (var item in list)
                {
                    var web = PeopleMapper.Instance.Map(item);
                    res.AddReturnedValue(await WebPeople.SendAsync(web));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            return res;
        }
        public static async Task<ReturnedSaveFuncInfo> SendToServerAsync(PeoplesBussines item)
            => await SendToServerAsync(new List<PeoplesBussines>() { item });
        public static async Task<ReturnedSaveFuncInfo> ResetAsync() => await UnitOfWork.Peoples.ResetAsync(Cache.ConnectionString);
        public static async Task<ReturnedSaveFuncInfo> ResendNotSentAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            var uiUpdater = ClsCache.SendData2ServerInstance?.People;
            try
            {
                if (uiUpdater != null)
                {
                    uiUpdater.ShortMessage = "در حال ارسال اشخاص";
                    uiUpdater.Status = SyncStatus.Syncing;
                    uiUpdater.FinalStatus = res;
                }

                var list = await GetAllNotSentAsync();
                if (list == null || list.Count <= 0) return res;
                if (uiUpdater != null) uiUpdater.TotalCount = list?.Count ?? 0;
                var current = 0;
                foreach (var item in list)
                {
                    current++;
                    if (uiUpdater != null)
                    {
                        uiUpdater.ShortMessage = $"شخص جاری: {item?.Name}";
                        uiUpdater.Count = current;
                    }

                    res.AddReturnedValue(await SendToServerAsync(item));
                }
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }
            finally
            {
                if (uiUpdater != null)
                {
                    if (res.HasError)
                    {
                        uiUpdater.ShortMessage = "با شکست مواجه شد";
                        uiUpdater.Status = SyncStatus.SyncFailed;
                    }
                    else
                    {
                        uiUpdater.ShortMessage = "با موفقیت انجام شد.";
                        uiUpdater.Status = SyncStatus.SyncedOk;
                    }
                }
            }
            return res;
        }
    }
}
