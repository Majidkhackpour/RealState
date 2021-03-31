using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class CheckPage : ICheckPage
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [ForeignKey("Check")]
        public Guid CheckGuid { get; set; }
        public DateTime? DatePardakht { get; set; }
        public long Number { get; set; }
        [ForeignKey("Tafsil")]
        public Guid? ReceptorGuid { get; set; }
        public DateTime? DateSarresid { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }
        public virtual DasteCheck Check { get; set; }
        public virtual Tafsil Tafsil { get; set; }
    }
}
