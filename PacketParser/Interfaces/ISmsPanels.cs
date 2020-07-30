namespace PacketParser.Interfaces
{
    public interface ISmsPanels : IHasGuid
    {
        string Name { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        string Sender { get; set; }
        string API { get; set; }
    }
}
