using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class PardakhtCheckAvalDore : IPardakhtCheckAvalDore
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string DasteCheckName { get; set; }

        [ForeignKey("CheckPage")]
        public Guid CheckPageGuid { get; set; }
        [ForeignKey("Tafsil")]
        public Guid TafsilGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public virtual CheckPage CheckPage { get; set; }
        public virtual Tafsil Tafsil { get; set; }
        public virtual Users User { get; set; }
    }
}
