using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class AdvisorBussines : IAdvisor
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public decimal Account_ => Math.Abs(Account);
        public string Diagnosis => Account.AccountDiagnosis();
        public string HardSerial => Cache.HardSerial;


        public static async Task<List<AdvisorBussines>> GetAllAsync(CancellationToken token) => await UnitOfWork.Advisor.GetAllAsync(Cache.ConnectionString,token);
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
                res.AddReturnedValue(await SaveTafsilAsync(tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await SaveMobileAsync(tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Advisor.SaveAsync(this, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebAdvisor.SaveAsync(this));
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
        public static async Task<List<AdvisorBussines>> GetAllAsync(string search,CancellationToken token)
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
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 x.Account.ToString().ToLower().Contains(item.ToLower()))
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
                return new List<AdvisorBussines>();
            }
        }
        public static async Task<AdvisorBussines> GetAsync(Guid guid) => await UnitOfWork.Advisor.GetAsync(Cache.ConnectionString, guid);
        public static AdvisorBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        private ReturnedSaveFuncInfo CheckValidation()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrEmpty(Name)) res.AddError("عنوان حساب نمی تواند خالی باشد");
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

                tf.Code = await TafsilBussines.NextCodeAsync(HesabType.Customer);
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
                    res.AddError("حساب انتخاب شده معتبر نمی باشد");
                    return res;
                }

                res.AddReturnedValue(await tafsil.ChangeStatusAsync(status, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await PhoneBookBussines.ChangeStatusAsync(Guid, status, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Advisor.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebAdvisor.SaveAsync(this));
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
        private async Task<ReturnedSaveFuncInfo> SaveMobileAsync(SqlTransaction tr)
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                res.AddReturnedValue(await PhoneBookBussines.RemoveAsync(Guid, tr));
                if (res.HasError) return res;

                var tellList = new List<PhoneBookBussines>();
                if (!string.IsNullOrEmpty(Mobile1))
                {
                    var mob1 = new PhoneBookBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Name = Name,
                        ParentGuid = Guid,
                        Tell = Mobile1,
                        Group = EnPhoneBookGroup.Advisor
                    };
                    tellList.Add(mob1);
                }
                if (!string.IsNullOrEmpty(Mobile2))
                {
                    var mob1 = new PhoneBookBussines()
                    {
                        Guid = Guid.NewGuid(),
                        Modified = DateTime.Now,
                        Status = true,
                        Name = Name,
                        ParentGuid = Guid,
                        Tell = Mobile2,
                        Group = EnPhoneBookGroup.Advisor
                    };
                    tellList.Add(mob1);
                }
                res.AddReturnedValue(await PhoneBookBussines.SaveRangeAsync(tellList, tr));
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
