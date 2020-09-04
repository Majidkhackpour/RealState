using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface IUserLog : IHasGuid
    {
        Guid UserGuid { get; set; }
        DateTime Date { get; set; }
        EnLogAction Action { get; set; }
        EnLogPart Part { get; set; }
        string Description { get; set; }
    }
}
