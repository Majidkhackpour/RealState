using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingZoncan : IBuildingZoncan
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)] public string Name { get; set; }
        public string Description { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public virtual ICollection<Building> Building { get; set; }
    }
}
