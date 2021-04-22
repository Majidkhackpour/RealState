using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class SanadDetail : ISanadDetails
    {
        [Column(Order = 1)]
        [Key]
        public Guid Guid { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [Index("IX_Sanad_Date", 2)]
        public DateTime Modified { get; set; }
        [Column(Order = 2)]
        [Key, ForeignKey("Sanad")]
        [Index("IX_Sanad_MasterGuid",1)]
        public Guid MasterGuid { get; set; }
        [ForeignKey("Moein")]
        public Guid MoeinGuid { get; set; }
        [ForeignKey("Tafsil")]
        public Guid TafsilGuid { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string Description { get; set; }
        public virtual Sanad Sanad { get; set; }
        public virtual Moein Moein { get; set; }
        public virtual Tafsil Tafsil { get; set; }
    }
}
