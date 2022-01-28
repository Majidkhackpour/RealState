using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingReview : IBuildingReview
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        [ForeignKey("Building")]
        public Guid BuildingGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        [ForeignKey("Tafsil")]
        public Guid CustometGuid { get; set; }
        public DateTime Date { get; set; }
        public string Report { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public virtual Building Building { get; set; }
        public virtual Users User { get; set; }
        public virtual Tafsil Tafsil { get; set; }
    }
}
