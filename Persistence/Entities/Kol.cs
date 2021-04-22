using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Kol : IKol
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public EnHesabGroup HesabGroup { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public decimal Account { get; set; }
        public virtual ICollection<Moein> Moein { get; set; }
    }
}
