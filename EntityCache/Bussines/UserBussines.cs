﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using Persistence;
using Services;
using Services.Access;
using Servicess.Interfaces.Building;
using WebHesabBussines;

namespace EntityCache.Bussines
{
    public class UserBussines : IUsers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public ServerStatus ServerStatus { get; set; } = ServerStatus.None;
        public DateTime ServerDeliveryDate { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private string _access = "";
        public string Access
        {
            get
            {
                if (string.IsNullOrEmpty(_access))
                    _access = Json.ToStringJson(UserAccess);
                return _access;
            }
            set
            {
                _access = value;
                _accessLevel = value.FromJson<AccessLevel>();
            }
        }
        private AccessLevel _accessLevel;
        public AccessLevel UserAccess
        {
            get => _accessLevel ?? (_accessLevel = new AccessLevel());
            set
            {
                _accessLevel = value;
                _access = Json.ToStringJson(value);
            }
        }
        public EnSecurityQuestion SecurityQuestion { get; set; }
        public string AnswerQuestion { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string HardSerial => Cache.HardSerial;

        public static async Task<UserBussines> GetAsync(Guid guid) => await UnitOfWork.Users.GetAsync(Cache.ConnectionString, guid);
        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.Users.GetAllAsync(Cache.ConnectionString);
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
                res.AddReturnedValue(await SaveMobileAsync(tr));
                if (res.HasError) return res;

                res.AddReturnedValue(await UnitOfWork.Users.SaveAsync(this, tr));
                if (res.HasError) return res;

                //if (Cache.IsSendToServer)
                //    _ = Task.Run(() => WebUser.SaveAsync(this));
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


                res.AddReturnedValue(await PhoneBookBussines.ChangeStatusAsync(Guid, status, tr));
                if (res.HasError) return res;
                res.AddReturnedValue(await UnitOfWork.Users.ChangeStatusAsync(this, status, tr));
                if (res.HasError) return res;
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
        public static async Task<List<UserBussines>> GetAllAsync(string search)
        {
            try
            {
                if (string.IsNullOrEmpty(search))
                    search = "";
                var res = await GetAllAsync();
                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => (!string.IsNullOrEmpty(x.Email) && (!string.IsNullOrEmpty(x.Mobile)) &&
                                                  (x.Name.ToLower().Contains(item.ToLower()) ||
                                                   x.UserName.ToLower().Contains(item.ToLower()) ||
                                                   x.Email.ToLower().Contains(item.ToLower()) ||
                                                   x.Mobile.Contains(item))))
                                ?.ToList();
                        }
                    }

                res = res?.OrderBy(o => o.Name).ToList();
                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<UserBussines>();
            }
        }
        public static UserBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
        public static async Task<bool> CheckUserNameAsync(Guid guid, string userName) => await UnitOfWork.Users.CheckUserNameAsync(Cache.ConnectionString, guid, userName);
        public static async Task<UserBussines> GetAsync(string userName) => await UnitOfWork.Users.GetAsync(Cache.ConnectionString, userName);
        public static async Task<UserBussines> GetByEmailAsync(string email) => await UnitOfWork.Users.GetByEmailAsync(Cache.ConnectionString, email);
        public static async Task<UserBussines> GetByMobileAsync(string mobile) => await UnitOfWork.Users.GetByMobilAsync(Cache.ConnectionString, mobile);
        public static async Task<List<UserBussines>> GetAllAsync(EnSecurityQuestion question, string answer) =>
            await UnitOfWork.Users.GetAllAsync(Cache.ConnectionString, question, answer);
        private async Task<ReturnedSaveFuncInfo> CheckValidationAsync()
        {
            var res = new ReturnedSaveFuncInfo();
            try
            {
                if (string.IsNullOrWhiteSpace(Name))
                    res.AddError("نام و نام خانوادگی نمی تواند خالی باشد");
                if (string.IsNullOrWhiteSpace(UserName))
                    res.AddError("نام کاربری نمی تواند خالی باشد");
                if (!await UserBussines.CheckUserNameAsync(Guid, UserName))
                    res.AddError("نام کاربری تکراری می باشد");
                if (string.IsNullOrWhiteSpace(Password))
                    res.AddError("کلمه عبور نمی تواند خالی باشد");
                if (!CheckPerssonValidation.CheckEmail(Email))
                    res.AddError("ایمیل وارد شده صحیح نمی باشد");
                if (!CheckPerssonValidation.CheckMobile(Mobile))
                    res.AddError("شماره موبایل وارد شده صحیح نمی باشد");
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

                var tel = new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Group = EnPhoneBookGroup.Users,
                    Name = Name,
                    ParentGuid = Guid,
                    Tell = Mobile,
                    Modified = Modified,
                    Status = true
                };
                res.AddReturnedValue(await tel.SaveAsync(tr));
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
