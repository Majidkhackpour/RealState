using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingRelatedOptions : IBuildingRelatedOptions
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [ForeignKey("Building")]
        public Guid BuildinGuid { get; set; }
        [ForeignKey("BuildingOption")]
        public Guid BuildingOptionGuid { get; set; }
        public virtual Building Building { get; set; }
        public virtual BuildingOptions BuildingOption { get; set; }
    }
}
