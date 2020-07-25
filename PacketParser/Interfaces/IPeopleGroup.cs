using System;

namespace PacketParser.Interfaces
{
    public interface IPeopleGroup : IHasGuid
    {
        string Name { get; set; }
        Guid ParentGuid { get; set; }
    }
}
