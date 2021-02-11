using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Kol : IKol
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public Guid GroupGuid { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public decimal Account { get; set; }
    }
}
