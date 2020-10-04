using System;
using PacketParser.Interfaces;

namespace EntityCache.ViewModels
{
    public class DivarCities : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
    }
}
