using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCache.Assistence;
using Nito.AsyncEx;
using PacketParser.Interfaces;

namespace EntityCache.Bussines
{
    public class PeoplesBankAccountBussines : IPeopleBankAccount
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Shobe { get; set; }
        public Guid ParentGuid { get; set; }


        public static async Task<List<PeoplesBankAccountBussines>> GetAllAsync(Guid parentGuid) =>
            await UnitOfWork.PeopleBankAccount.GetAllAsync(parentGuid);

        public static List<PeoplesBankAccountBussines> GetAll(Guid parentGuid) =>
            AsyncContext.Run(() => GetAllAsync(parentGuid));
    }
}
