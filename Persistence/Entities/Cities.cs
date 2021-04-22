using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Cities : ICities
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [ForeignKey("State")]
        public Guid StateGuid { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<BuildingRequest> BuildingRequest { get; set; }
        public virtual ICollection<Regions> Region { get; set; }
    }
}
