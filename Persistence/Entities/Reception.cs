using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Reception : IReception
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public long Number { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        [ForeignKey("Tafsil")]
        public Guid TafsilGuid { get; set; }
        [ForeignKey("Moein")]
        public Guid MoeinGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public long SanadNumber { get; set; }
        public virtual Users User { get; set; }
        public virtual Tafsil Tafsil { get; set; }
        public virtual Moein Moein { get; set; }
        public virtual ICollection<ReceptionCheck> ReceptionCheck { get; set; }
        public virtual ICollection<ReceptionNaqd> ReceptionNaqd { get; set; }
        public virtual ICollection<ReceptionHavale> ReceptionHavale { get; set; }
    }
}
