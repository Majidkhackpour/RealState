using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Regions : IRegions
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [ForeignKey("City")]
        public Guid CityGuid { get; set; }
        public virtual Cities City { get; set; }
        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<BuildingRequestRegion> BuildingRequestRegion { get; set; }
    }
}
