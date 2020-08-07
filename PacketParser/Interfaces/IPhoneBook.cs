using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface IPhoneBook : IHasGuid
    {
        string Name { get; set; }
        string Tell { get; set; }
        EnPhoneBookGroup Group { get; set; }
        Guid ParentGuid { get; set; }
    }
}
