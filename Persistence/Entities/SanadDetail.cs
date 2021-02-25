using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class SanadDetail : ISanadDetails
    {
        [Column(Order = 1)]
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [Column(Order = 2)]
        [Key, ForeignKey("Sanad")]
        public Guid MasterGuid { get; set; }
        public Guid MoeinGuid { get; set; }
        [MaxLength(20)]
        public string MoeinCode { get; set; }
        [MaxLength(200)]
        public string MoeinName { get; set; }
        public Guid TafsilGuid { get; set; }
        [MaxLength(20)]
        public string TafsilCode { get; set; }
        [MaxLength(200)]
        public string TafsilName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        public virtual Sanad Sanad { get; set; }
    }
}
