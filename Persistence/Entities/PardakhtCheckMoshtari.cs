using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class PardakhtCheckMoshtari : IPardakhtCheckMoshtari
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        [ForeignKey("ReceptionCheck")]
        public Guid CheckGuid { get; set; }
        [ForeignKey("Pardakht")]
        public Guid MasterGuid { get; set; }
        public virtual ReceptionCheck ReceptionCheck { get; set; }
        public virtual Pardakht Pardakht { get; set; }
    }
}
