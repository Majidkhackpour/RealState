using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Pardakht : IPardakht
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Tafsil")]
        public Guid TafsilGuid { get; set; }
        [ForeignKey("Moein")]
        public Guid MoeinGuid { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public long Number { get; set; }
        public long SanadNumber { get; set; }
        public virtual Users User { get; set; }
        public virtual Tafsil Tafsil { get; set; }
        public virtual Moein Moein { get; set; }
        public virtual ICollection<PardakhtNaqd> PardakhtNaqd { get; set; }
        public virtual ICollection<PardakhtHavale> PardakhtHavale { get; set; }
        public virtual ICollection<PardakhtCheckMoshtari> PardakhtCheckMoshtari { get; set; }
        public virtual ICollection<PardakhtCheckShakhsi> PardakhtCheckShakhsi { get; set; }
    }
}
