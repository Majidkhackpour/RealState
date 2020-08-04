using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class Simcard : ISimcard
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public long Number { get; set; }
        [MaxLength(200)]
        public string Owner { get; set; }
        public string Token { get; set; }
        [MaxLength(50)]
        public string Operator { get; set; }
    }
}
