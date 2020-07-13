using System;

namespace PacketParser.Interfaces
{
    public interface IRegions : IHasGuid
    {
        string Name { get; set; }
        Guid CityGuid { get; set; }
    }
}
