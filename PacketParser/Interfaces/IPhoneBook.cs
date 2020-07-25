namespace PacketParser.Interfaces
{
    public interface IPhoneBook : IHasGuid
    {
        string Name { get; set; }
        string Tell { get; set; }
        string Email { get; set; }
        bool IsSystem { get; set; }
    }
}
