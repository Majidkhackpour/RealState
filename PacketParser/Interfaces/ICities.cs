using System;

namespace PacketParser.Interfaces
{
    public interface ICities : IHasGuid
    {
        string Name { get; set; }
        Guid StateGuid { get; set; }
    }
}
