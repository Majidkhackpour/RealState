using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class Reception : IReception
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid Receptor { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public decimal NaqdPrice { get; set; }
        public decimal BankPrice { get; set; }
        [MaxLength(50)]
        public string FishNo { get; set; }
        public decimal Check { get; set; }
        [MaxLength(50)]
        public string CheckNo { get; set; }
        [MaxLength(50)]
        public string SarResid { get; set; }
        [MaxLength(50)]
        public string BankName { get; set; }
    }
}
