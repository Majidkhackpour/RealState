using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Calendar : ICalendar
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public DateTime DateM { get; set; }
        [MaxLength(500)]
        public string Monasebat { get; set; }
        public string Description { get; set; }
        public bool isTatil { get; set; }
    }
}
