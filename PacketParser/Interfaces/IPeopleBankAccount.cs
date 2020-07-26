using System;

namespace PacketParser.Interfaces
{
    public interface IPeopleBankAccount : IHasGuid
    {
        string BankName { get; set; }
        string AccountNumber { get; set; }
        string Shobe { get; set; }
        Guid ParentGuid { get; set; }
    }
}
