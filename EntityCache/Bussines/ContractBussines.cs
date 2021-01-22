﻿using System;
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
    public class ContractBussines : IContract
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public string DateSh => Calendar.MiladiToShamsi(DateM);
        public bool Status { get; set; } = true;
        public DateTime DateM { get; set; } = DateTime.Now;
        public long Code { get; set; }
        public bool IsTemp { get; set; }
        public Guid FirstSideGuid { get; set; }
        public string fName { get; set; }
        public Guid SecondSideGuid { get; set; }
        public Guid BuildingGuid { get; set; }
        public Guid UserGuid { get; set; }
        public string UserName { get; set; }
        public string sName { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        public string CheckNo { get; set; }
        public string BankName { get; set; }
        public string Shobe { get; set; }
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeDateSh => Calendar.MiladiToShamsi(DischargeDate);
        public DateTime? SetDocDate { get; set; }
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        public Guid BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
        private ContractFinanceBussines _finance;
        public ContractFinanceBussines Finance
        {
            get
            {
                if (_finance != null) return _finance;
                _finance = ContractFinanceBussines.Get(Guid, Status);
                return _finance;
            }
            set => _finance = value;
        }
        public decimal FPrice { get; set; }
        public decimal SPrice { get; set; }
        public string HardSerial => Cache.HardSerial;



        public static async Task<List<ContractBussines>> GetAllAsync() => await UnitOfWork.Contract.GetAllAsyncBySp();
        public static async Task<List<ContractBussines>> GetAllAsync(string search)
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
                            res = res.Where(x => x.fName.ToLower().Contains(item.ToLower()) ||
                                                 x.sName.ToLower().Contains(item.ToLower()) ||
                                                 x.UserName.ToLower().Contains(item.ToLower()) ||
                                                 x.Code.ToString().ToLower().Contains(item.ToLower()))
                                ?.ToList();
                        }
                    }

                return res;
            }
            catch (OperationCanceledException)
            { return null; }
            catch (Exception ex)
            {
                WebErrorLog.ErrorInstence.StartErrorLog(ex);
                return new List<ContractBussines>();
            }
        }
        public static async Task<ContractBussines> GetAsync(Guid guid) => await UnitOfWork.Contract.GetAsync(guid);
        public static ContractBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));
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

                if (Finance != null)
                {
                    var list = await ContractFinanceBussines.GetAsync(Guid, Status);
                    if (list != null)
                    {
                        res.AddReturnedValue(
                            await UnitOfWork.ContractFinance.RemoveAsync(list.Guid,
                                tranName));
                        res.ThrowExceptionIfError();
                    }

                    res.AddReturnedValue(
                        await UnitOfWork.ContractFinance.SaveAsync(Finance, tranName));
                    res.ThrowExceptionIfError();
                }

                res.AddReturnedValue(await UnitOfWork.Contract.SaveAsync(this, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebContract.SaveAsync(this));
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


                res.AddReturnedValue(await UnitOfWork.Contract.ChangeStatusAsync(this, status, tranName));
                res.ThrowExceptionIfError();
                if (autoTran)
                {
                    //CommitTransAction
                }

                if (Cache.IsSendToServer)
                    _ = Task.Run(() => WebContract.SaveAsync(this));
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
        public static async Task<string> NextCodeAsync() => await UnitOfWork.Contract.NextCodeAsync();
        public static async Task<bool> CheckCodeAsync(string code, Guid guid) =>
            await UnitOfWork.Contract.CheckCodeAsync(code, guid);
        public static async Task<int> DbCount(Guid userGuid) => await UnitOfWork.Contract.DbCount(userGuid);
    }
}
