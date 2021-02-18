using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class DasteCheck : IDasteCheck
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public long SerialNumber { get; set; }
        public Guid BankGuid { get; set; }
        public bool IsSarresidShode { get; set; }
    }
}
