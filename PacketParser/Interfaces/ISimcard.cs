using System;

namespace PacketParser.Interfaces
{
    public interface ISimcard : IHasGuid
    {
        long Number { get; set; }
        string Owner { get; set; }
        string Operator { get; set; }
        bool isSheypoorBlocked { get; set; }
        DateTime NextUseSheypoor { get; set; }
        DateTime NextUseDivar { get; set; }
    }
}
