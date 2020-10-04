
using Services;

namespace PacketParser.Interfaces
{
    public interface IAdvTokens : IHasGuid
    {
        string Token { get; set; }
        long Number { get; set; }
        AdvertiseType Type { get; set; }
    }
}
