using System;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class DasteCheckBussines : IDasteCheck
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public long SerialNumber { get; set; }
        public Guid BankGuid { get; set; }
        public bool IsSarresidShode { get; set; }
    }
}
