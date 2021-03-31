﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingCondition : IBuildingCondition
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<BuildingRequest> BuildingRequest { get; set; }
    }
}
