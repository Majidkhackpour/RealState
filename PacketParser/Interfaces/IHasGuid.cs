using System;

namespace PacketParser.Interfaces
{
    public interface IHasGuid
    {
        Guid Guid { get; set; }
        DateTime Modified { get; set; }
    }
}
