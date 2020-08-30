using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface IContractFinance : IHasGuid
    {
        Guid ConGuid { get; set; }
        EnContractBabat fBabat { get; set; }
        EnContractBabat sBabat { get; set; }
        decimal FirstDiscount { get; set; }
        decimal SecondDiscount { get; set; }
        decimal FirstAddedValue { get; set; }
        decimal SecondAddedValue { get; set; }
        decimal FirstTotalPrice { get; set; }
        decimal SecondTotalPrice { get; set; }
    }
}
