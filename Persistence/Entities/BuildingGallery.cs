using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingGallery : IBuildingGallery
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [ForeignKey("Building")]
        public Guid BuildingGuid { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }

        public virtual Building Building { get; set; }
    }
}
