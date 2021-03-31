using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("Kol")]
        public Guid KolGuid { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public virtual Kol Kol { get; set; }
        public virtual ICollection<SanadDetail> SanadDetails { get; set; }
        public virtual ICollection<Reception> Reception { get; set; }
        public virtual ICollection<ReceptionNaqd> ReceptionNaqd { get; set; }
        public virtual ICollection<ReceptionHavale> ReceptionHavale { get; set; }
        public virtual ICollection<ReceptionCheck> ReceptionCheck { get; set; }
        public virtual ICollection<ReceptionCheckAvalDore> ReceptionCheckAvalDore { get; set; }
        public virtual ICollection<Pardakht> Pardakht { get; set; }
        public virtual ICollection<PardakhtHavale> PardakhtHavale { get; set; }
        public virtual ICollection<PardakhtNaqd> PardakhtNaqd { get; set; }
    }
}
