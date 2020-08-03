namespace PacketParser.Interfaces
{
    public interface ISimcard : IHasGuid
    {
        long Number { get; set; }
        string Owner { get; set; }
        string Token { get; set; }
        string Operator { get; set; }
    }
}
