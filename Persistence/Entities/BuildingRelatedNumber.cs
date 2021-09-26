using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingRelatedNumber : IBuildingRelatedNumber
    {
        [Key, Column(Order = 0)]
        public Guid BuildingGuid { get; set; }
        [Key, Column(Order = 1)]
        public string Number { get; set; }
    }
}
