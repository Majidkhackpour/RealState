using System;
using PacketParser.Interfaces;

namespace EntityCache.Bussines
{
    public class PeoplesBankAccountBussines : IPeopleBankAccount
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Shobe { get; set; }
    }
}
