using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;
using PacketParser.Services;

namespace EntityCache.Bussines
{
    public class PeoplesBussines : IPeoples
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
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
        public Guid UserGuid { get; set; }
        public Guid GroupGuid { get; set; }
        private List<PhoneBookBussines> _tellList;
        public List<PhoneBookBussines> TellList
        {
            get
            {
                if (_tellList != null) return _tellList;
                _tellList = PhoneBookBussines.GetAll(Guid);
                return _tellList;
            }
            set => _tellList = value;
        }
        private List<PeoplesBankAccountBussines> _bankList;
        public List<PeoplesBankAccountBussines> BankList
        {
            get
            {
                if (_bankList != null) return _bankList;
                _bankList = PeoplesBankAccountBussines.GetAll(Guid);
                return _bankList;
            }
            set => _bankList = value;
        }

        public static async Task<List<PeoplesBussines>> GetAllAsync() => await UnitOfWork.Peoples.GetAllAsync();

        public static async Task<PeoplesBussines> GetAsync(Guid guid) => await UnitOfWork.Peoples.GetAsync(guid);

        public static async Task<List<PeoplesBussines>> GetAllAsync(Guid parentGuid, bool status) =>
            await UnitOfWork.Peoples.GetAllAsync(parentGuid, status);

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

                res.AddReturnedValue(await UnitOfWork.Peoples.SaveAsync(this, tranName));
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

                res.AddReturnedValue(await UnitOfWork.Peoples.ChangeStatusAsync(this, status, tranName));
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

        public static PeoplesBussines Get(Guid guid) => AsyncContext.Run(() => GetAsync(guid));

        public static List<PeoplesBussines> GetAll() => AsyncContext.Run(GetAllAsync);

        public static async Task<string> NextCodeAsync() => await UnitOfWork.Peoples.NextCodeAsync();

        public static string NextCode() => AsyncContext.Run(NextCodeAsync);
    }
}
