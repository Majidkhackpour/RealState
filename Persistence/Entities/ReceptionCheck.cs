using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class ReceptionCheck : IReceptionCheck
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
        public DateTime DateM { get; set; }
        [ForeignKey("Reception")]
        public Guid MasterGuid { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string CheckNumber { get; set; }
        [MaxLength(200)]
        public string PoshtNomre { get; set; }
        public decimal Price { get; set; }
        public EnCheckM CheckStatus { get; set; }
        public virtual Reception Reception { get; set; }
    }
}
