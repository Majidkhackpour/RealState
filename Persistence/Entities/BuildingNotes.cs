using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingNotes : IBuildingNote
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [ForeignKey("Building")]
        public Guid BuildingGuid { get; set; }
        public string Note { get; set; }

        public virtual Building Building { get; set; }
    }
}
