namespace PacketParser.Interfaces
{
    public interface IDocumentType : IHasGuid
    {
        string Name { get; set; }
    }
}
