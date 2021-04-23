using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Simcard : ISimcard
    {
        [Key]
        public Guid Guid { get; set; }
        public long Number { get; set; }
        [MaxLength(200)]
        public string Owner { get; set; }
        [MaxLength(50)]
        public string Operator { get; set; }
        public bool isSheypoorBlocked { get; set; }
        public DateTime NextUseSheypoor { get; set; }
        public DateTime NextUseDivar { get; set; }
        public bool Status { get; set; }
    }
}
