using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class DasteCheck : IDasteCheck
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(100)]
        public string SerialNumber { get; set; }
        [ForeignKey("Bank")]
        public Guid BankGuid { get; set; }
        public long FromNumber { get; set; }
        public long ToNumber { get; set; }
        public string Description { get; set; }
        public virtual Bank Bank { get; set; }
        public virtual ICollection<CheckPage> CheckPage { get; set; }
    }
}
