using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Moein : IMoein
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public Guid KolGuid { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public virtual ICollection<SanadDetail> SanadDetails { get; set; }
        public virtual ICollection<Reception> Reception { get; set; }
        public virtual ICollection<ReceptionNaqd> ReceptionNaqd { get; set; }
        public virtual ICollection<ReceptionHavale> ReceptionHavale { get; set; }
    }
}
