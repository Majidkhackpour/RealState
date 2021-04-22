using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class PardakhtCheckMoshtari : IPardakhtCheckMoshtari
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public string Description { get; set; }
        public Guid CheckGuid { get; set; }
        [ForeignKey("Pardakht")]
        public Guid MasterGuid { get; set; }
        public virtual Pardakht Pardakht { get; set; }
    }
}
