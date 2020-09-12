using System;

namespace PacketParser.Interfaces
{
    public interface ISmsLog : IHasGuid
    {
        DateTime Date { get; set; }
        Guid UserGuid { get; set; }
        string Sender { get; set; }
        string Reciver { get; set; }
        string Message { get; set; }
        decimal Cost { get; set; }
        long MessageId { get; set; }
        string StatusText { get; set; }
    }
}
