using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class ReceptionCheckAvalDore : IReceptionCheckAvalDore
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
        public DateTime DateM { get; set; }
        public DateTime DateSarResid { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string CheckNumber { get; set; }
        [MaxLength(200)]
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public Guid SandouqTafsilGuid { get; set; }
        [ForeignKey("Moein")]
        public Guid SandouqMoeinGuid { get; set; }
        [ForeignKey("SandouqTafsilGuid_Tafsil")]
        public Guid TafsilGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public virtual Moein Moein { get; set; }
        public virtual Tafsil SandouqTafsilGuid_Tafsil { get; set; }
        public virtual Users User { get; set; }
    }
}
