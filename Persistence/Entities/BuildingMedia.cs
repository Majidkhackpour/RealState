using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingMedia : IBuildingMedia
    {
        [Key] public Guid Guid { get; set; }
        [ForeignKey("Building")]
        public Guid BuildingGuid { get; set; }
        [MaxLength(100)]
        public string MediaName { get; set; }
        public virtual Building Building { get; set; }
    }
}
