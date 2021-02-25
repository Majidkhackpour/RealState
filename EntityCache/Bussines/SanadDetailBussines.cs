using System;
using Services.Interfaces.Building;

namespace EntityCache.Bussines
{
    public class SanadDetailBussines : ISanadDetails
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid MasterGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        public string MoeinCode { get; set; }
        public string MoeinName { get; set; }
        public Guid TafsilGuid { get; set; }
        public string TafsilCode { get; set; }
        public string TafsilName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
    }
}
