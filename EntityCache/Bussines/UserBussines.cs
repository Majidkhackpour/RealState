using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
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
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public decimal Account_ => Math.Abs(Account);

        public static async Task<UserBussines> GetAsync(Guid guid) => await UnitOfWork.Users.GetAsync(guid);

        public static async Task<List<UserBussines>> GetAllAsync() => await UnitOfWork.Users.GetAllAsync();

        public async Task<ReturnedSaveFuncInfo> SaveAsync(bool setEftetah,bool sendToServer, string tranName = "")
        {
            var res = new ReturnedSaveFuncInfo();
            var autoTran = string.IsNullOrEmpty(tranName);
            if (autoTran) tranName = Guid.NewGuid().ToString();
            try
            {
                if (autoTran)
                { //BeginTransaction
                }


                var list = await PhoneBookBussines.GetAllAsync(Guid, Status);
                res.AddReturnedValue(
                    await UnitOfWork.PhoneBook.RemoveRangeAsync(list.Select(q => q.Guid).ToList(),
                        tranName));
                res.ThrowExceptionIfError();

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

                var gardesh = await GardeshHesabBussines.GetAsync(Guid, Guid.Empty, true);
                if (setEftetah)
                {
                    if (gardesh == null)
                    {
                        var g = new GardeshHesabBussines()
                        {
                            Guid = Guid.NewGuid(),
                            Babat = EnAccountBabat.Ins,
                            Description = "افتتاح حساب",
                            PeopleGuid = Guid,
                            Price = Account_,
                            ParentGuid = Guid.Empty
                        };
                        if (Account == 0) g.Type = EnAccountType.BiHesab;
                        if (Account > 0) g.Type = EnAccountType.Bed;
                        if (Account < 0) g.Type = EnAccountType.Bes;
                        res.AddReturnedValue(
                            await UnitOfWork.GardeshHesab.SaveAsync(g, tranName));
                        res.ThrowExceptionIfError();
                    }
                    else
                    {
                        gardesh.Price = Math.Abs(AccountFirst);
                        if (Account == 0) gardesh.Type = EnAccountType.BiHesab;
                        if (Account > 0) gardesh.Type = EnAccountType.Bed;
                        if (Account < 0) gardesh.Type = EnAccountType.Bes;
                        res.AddReturnedValue(
                            await UnitOfWork.GardeshHesab.SaveAsync(gardesh, tranName));
                        res.ThrowExceptionIfError();
                    }
                }

                res.AddReturnedValue(await UnitOfWork.Users.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (sendToServer)
                    _ = Task.Run(() => WebUser.SaveAsync(this));
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
