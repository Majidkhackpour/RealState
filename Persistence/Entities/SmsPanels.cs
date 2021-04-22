using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class SmsPanels : ISmsPanels
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Sender { get; set; }
        public string API { get; set; }
    }
}
