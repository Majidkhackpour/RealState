using Servicess.Interfaces.Building;
using System;

namespace EntityCache.Bussines
{
    public class PeoplesBankAccountBussines : IPeopleBankAccount
    {
        public Guid Guid { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Shobe { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
