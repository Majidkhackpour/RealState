using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Sanad : ISanad
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime DateM { get; set; }
        public string Description { get; set; }
        public long Number { get; set; }
        public EnSanadStatus SanadStatus { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public EnSanadType SanadType { get; set; }
        public virtual ICollection<SanadDetail> SanadDetails { get; set; }
        public virtual Users User { get; set; }
    }
}
