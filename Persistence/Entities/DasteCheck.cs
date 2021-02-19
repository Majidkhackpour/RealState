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
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        public Guid BankGuid { get; set; }
        public long FromNumber { get; set; }
        public long ToNumber { get; set; }
        public string Description { get; set; }
    }
}
