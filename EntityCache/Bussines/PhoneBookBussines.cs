﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class PhoneBookBussines : IPhoneBook
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public string Tell { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public string GroupName => Group.GetDisplay();
        public Guid ParentGuid { get; set; }
        public bool IsChecked { get; set; }


        public static async Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.PhoneBook.GetAllBySpAsync(parentGuid, status);

        public static async Task<List<PhoneBookBussines>> GetAllAsync() => await UnitOfWork.PhoneBook.GetAllAsync();

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

                res.AddReturnedValue(await UnitOfWork.PhoneBook.ChangeStatusAsync(this, status, tranName));
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

        public static async Task<List<PhoneBookBussines>> GetAllAsync(Guid parentGuid, string search, EnPhoneBookGroup group)
        {
            try
            {
                if (string.IsNullOrEmpty(search)) search = "";
                var res = new List<PhoneBookBussines>();
                if (parentGuid != Guid.Empty)
                    res = await GetAllAsync(parentGuid, true);
                else res = await GetAllAsync();
                if (group != EnPhoneBookGroup.All)
                    res = res.Where(q => q.Group == group).ToList();

                var searchItems = search.SplitString();
                if (searchItems?.Count > 0)
                    foreach (var item in searchItems)
                    {
                        if (!string.IsNullOrEmpty(item) && item.Trim() != "")
                        {
                            res = res.Where(x => x.Name.ToLower().Contains(item.ToLower()) ||
                                                 (!string.IsNullOrEmpty(x.Tell) &&
                                                  x.Tell.ToLower().Contains(item.ToLower())) ||
                                                 x.GroupName.ToLower().Contains(item.ToLower()))
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
                return new List<PhoneBookBussines>();
            }
        }

        public static async Task<PhoneBookBussines> GetAsync(Guid guid) => await UnitOfWork.PhoneBook.GetAsync(guid);
        public static PhoneBookBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

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

                res.AddReturnedValue(await UnitOfWork.PhoneBook.SaveAsync(this, tranName));
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
    }
}
