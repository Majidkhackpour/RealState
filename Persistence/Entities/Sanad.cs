using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Sanad : ISanad
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public long Number { get; set; }
        public EnSanadStatus SanadStatus { get; set; }
        public Guid UserGuid { get; set; }
        public decimal SumDebit { get; set; }
        public decimal SumCredit { get; set; }
        public EnSanadType SanadType { get; set; }
        public virtual ICollection SanadDetails { get; set; }
    }
}
