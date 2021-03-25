using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Advisor : IAdvisor
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
