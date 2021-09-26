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
        public string CodeInArchive { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string AccountType => Account.AccountDiagnosis();
        public string FirstNumber => TellList?.FirstOrDefault()?.Tell ?? "";
        public bool IsChecked { get; set; }
        public string HardSerial => Cache.HardSerial;
        public List<PhoneBookBussines> TellList { get; set; }
        public List<PeoplesBankAccountBussines> BankList { get; set; }
        public bool IsModified { get; set; } = false;
        public static Guid DefualtGuid
        {
            get
            {
                if (_defaultGuid != Guid.Empty) return _defaultGuid;
                var def = AsyncContext.Run(GetDefaultPeopleAsync);
                _defaultGuid = def?.Guid ?? Guid.Empty;
                return _defaultGuid;
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
                res.AddReturnedValue(await SaveTafsilAsync(tr));
                if (res.HasError) return res;

                if (TellList?.Count > 0)
                {
                    res.AddReturnedValue(await SaveMobileAsync(tr));
                    if (res.HasError) return res;
                }
                if (BankList?.Count > 0)
                {
                    res.AddReturnedValue(await SaveBankAccountAsync(tr));
                    if (res.HasError) return res;
                }

                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tr));
                if (res.HasError) return res;

                var action = IsModified ? EnLogAction.Update : EnLogAction.Insert;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Peoples, tr));
                if (res.HasError) return res;
                RaiseEvent();
                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeople.SaveAsync(PeopleMapper.Instance.Map(this)));
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
                res.AddReturnedValue(await UnitOfWork.Peoples.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                var action = status ? EnLogAction.Enable : EnLogAction.Delete;
                res.AddReturnedValue(await UserLogBussines.SaveAsync(action, EnLogPart.Peoples, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebPeople.SaveAsync(PeopleMapper.Instance.Map(this)));
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
        public static PeoplesBussines Get(Guid guid, Guid? buildingGuid) => AsyncContext.Run(() => GetAsync(guid, buildingGuid));
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
                                                 x.GroupName.ToLower().Contains(item.ToLower()) ||
                                                 (!string.IsNullOrEmpty(x.CodeInArchive) && x.CodeInArchive.ToLower().Contains(item.ToLower())));
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
        private async Task<ReturnedSaveFuncInfo> SaveTafsilAsync(SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                var tf = await TafsilBussines.GetAsync(Guid) ?? new TafsilBussines
                {
                    Guid = Guid,
                    DateM = DateTime.Now,
                    Account = 0,
                    HesabType = HesabType.Customer,
                    Modified = Modified,
                    Status = true,
                    isSystem = false
                };

                tf.Code = Code;
                tf.Name = Name;
                tf.Description = "";
                tf.AccountFirst = AccountFirst;

                res.AddReturnedValue(await tf.SaveAsync(tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveMobileAsync(SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await PhoneBookBussines.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                foreach (var item in TellList)
                {
                    item.ParentGuid = Guid;
                    item.Name = Name;
                }

                res.AddReturnedValue(await PhoneBookBussines.SaveRangeAsync(TellList, tr));
            }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                res.AddReturnedValue(ex);
            }

            return res;
        }
        private async Task<ReturnedSaveFuncInfo> SaveBankAccountAsync(SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await PeoplesBankAccountBussines.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                foreach (var item in BankList)
                {
                    item.ParentGuid = Guid;
                    res.AddReturnedValue(await BankSegestBussines.CheckBankAsync(item.BankName, tr));
                    if (res.HasError) return res;
                }
                res.AddReturnedValue(await PeoplesBankAccountBussines.SaveRangeAsync(BankList, tr));
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
        private static async Task<PeoplesBussines> GetDefaultPeopleAsync() => await GetAsync(ParentDefaults.TafsilCoding.DefualtCustomer, null);
    }
}
