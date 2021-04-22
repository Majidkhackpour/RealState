using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class PardakhtCheckShakhsi : IPardakhtCheckShakhsi
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime DateSarResid { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string Number { get; set; }
        public decimal Price { get; set; }
        public DateTime DateM { get; set; }
        [ForeignKey("CheckPage")]
        public Guid CheckPageGuid { get; set; }
        [ForeignKey("Pardakht")]
        public Guid MasterGuid { get; set; }
        public virtual CheckPage CheckPage { get; set; }
        public virtual Pardakht Pardakht { get; set; }
    }
}
