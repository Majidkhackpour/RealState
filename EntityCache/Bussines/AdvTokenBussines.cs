using PacketParser.Interfaces;
using Services;
using System;
using System.Threading.Tasks;

namespace EntityCache.Bussines
{
    public class AdvTokenBussines : IAdvTokens
    {
        public string Token { get; set; }
        public AdvertiseType Type { get; set; }
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public long Number { get; set ; }

        public static async Task<AdvTokenBussines> GetTokenAsync(long number, AdvertiseType type)
        {
            throw new NotImplementedException();
        }
        public async Task<ReturnedSaveFuncInfo> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<ReturnedSaveFuncInfo> RemoveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
