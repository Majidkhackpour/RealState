using System;
using Services;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class TempBussines : ITemp
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public EnTemp Type { get; set; }
        public Guid ObjectGuid { get; set; }
    }
}
