using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class PardakhtHavale : IPardakhtHavale
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string Number { get; set; }
        public decimal Price { get; set; }
        [ForeignKey("Tafsil")]
        public Guid BankTafsilGuid { get; set; }
        [ForeignKey("Moein")]
        public Guid BankMoeinGuid { get; set; }
        [ForeignKey("Pardakht")]
        public Guid MasterGuid { get; set; }
        public virtual Tafsil Tafsil { get; set; }
        public virtual Moein Moein { get; set; }
        public virtual Pardakht Pardakht { get; set; }
    }
}
