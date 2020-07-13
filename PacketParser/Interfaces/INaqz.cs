namespace PacketParser.Interfaces
{
    public interface INaqz : IHasGuid
    {
        string Message { get; set; }
        int UseCount { get; set; }
    }
}
