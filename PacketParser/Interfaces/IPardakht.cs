using System;

namespace PacketParser.Interfaces
{
    public interface IPardakht : IHasGuid
    {
        Guid Payer { get; set; }
        DateTime CreateDate { get; set; }
        string Description { get; set; }
        decimal NaqdPrice { get; set; }
        decimal BankPrice { get; set; }
        string FishNo { get; set; }
        decimal Check { get; set; }
        string CheckNo { get; set; }
        string SarResid { get; set; }
        string BankName { get; set; }
    }
}
