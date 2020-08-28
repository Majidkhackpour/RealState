using System;

namespace PacketParser.Interfaces
{
    public interface IPeoples : IHasGuid
    {
        string Code { get; set; }
        string Name { get; set; }
        string NationalCode { get; set; }
        string IdCode { get; set; }
        string FatherName { get; set; }
        string PlaceBirth { get; set; }
        string DateBirth { get; set; }
        string Address { get; set; }
        string IssuedFrom { get; set; }
        string PostalCode { get; set; }
        Guid GroupGuid { get; set; }
        decimal Account { get; set; }
        decimal AccountFirst { get; set; }
    }
}
