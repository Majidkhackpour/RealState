using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingWindow : IBuildingWindow
    {
        [Key]
        public Guid Guid { get; set; }
        public bool Status { get; set; }
        public DateTime Modified { get; set; }
        [MaxLength(250)] public string Name { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public virtual ICollection<Building> Building { get; set; }
    }
}
