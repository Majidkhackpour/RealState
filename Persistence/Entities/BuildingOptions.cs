using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class BuildingOptions : IBuildingOptions
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
    }
}
