using System;
using PacketParser.Interfaces;
using Services;

namespace EntityCache.Bussines
{
    public class UserLogBussines : IUserLog
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime Date { get; set; }
        public EnLogAction Action { get; set; }
        public EnLogPart Part { get; set; }
        public string Description { get; set; }
    }
}
