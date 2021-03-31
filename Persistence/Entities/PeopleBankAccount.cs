using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class PeopleBankAccount : IPeopleBankAccount
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
        [MaxLength(200)]
        public string AccountNumber { get; set; }
        [MaxLength(200)]
        public string Shobe { get; set; }
        [ForeignKey("Tafsil")]
        public Guid ParentGuid { get; set; }
        public virtual Tafsil Tafsil { get; set; }
    }
}
