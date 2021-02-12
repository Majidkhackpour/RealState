using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Tafsil : ITafsil
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public bool isSystem { get; set; }
    }
}
