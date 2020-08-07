﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class UserBussines : IUsers
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Access { get; set; }
        public EnSecurityQuestion SecurityQuestion { get; set; }
        public string AnswerQuestion { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }



        public static async Task<UserBussines> GetAsync(Guid guid) => await UnitOfWork.Users.GetAsync(guid);

        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.Users.GetAllAsync();

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

                var tel = new PhoneBookBussines()
                {
                    Guid = Guid.NewGuid(),
                    Group = EnPhoneBookGroup.Users,
                    Name = Name,
                    ParentGuid = Guid,
                    Tell = Mobile
                };

                res.AddReturnedValue(await UnitOfWork.PhoneBook.SaveAsync(tel, tranName));
                res.ThrowExceptionIfError();

                res.AddReturnedValue(await UnitOfWork.Users.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
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

                var tel = await PhoneBookBussines.GetAllAsync(Guid, !status);
                foreach (var item in tel.ToList())
                {
                    res.AddReturnedValue(
                        await item.ChangeStatusAsync(status, tranName));
                    res.ThrowExceptionIfError();
                }

                res.AddReturnedValue(await UnitOfWork.Users.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }
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

        public static List<UserBussines> GetAll(string search) => AsyncContext.Run(() => GetAllAsync(search));

        public static UserBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public static async Task<bool> CheckUserNameAsync(Guid guid, string userName) =>
            await UnitOfWork.Users.CheckUserNameAsync(guid, userName);

        public static async Task<UserBussines> GetAsync(string userName) => await UnitOfWork.Users.GetAsync(userName);

        public static async Task<UserBussines> GetByEmailAsync(string email) => await UnitOfWork.Users.GetByEmailAsync(email);

        public static async Task<UserBussines> GetByMobileAsync(string mobile) => await UnitOfWork.Users.GetByMobilAsync(mobile);

        public static async Task<List<UserBussines>> GetAllAsync(EnSecurityQuestion question, string answer) =>
            await UnitOfWork.Users.GetAllAsync(question, answer);
    }
}
