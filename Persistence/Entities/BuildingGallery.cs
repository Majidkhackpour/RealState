using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingGallery : IBuildingGallery
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid BuildingGuid { get; set; }
        [MaxLength(100)]
        public string ImageName { get; set; }
    }
}
