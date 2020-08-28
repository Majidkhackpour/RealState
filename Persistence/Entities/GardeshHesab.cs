using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;
using Services;

namespace Persistence.Entities
{
    public class GardeshHesab : IGardeshHesab
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public Guid PeopleGuid { get; set; }
        public decimal Price { get; set; }
        public EnAccountType Type { get; set; }
        public EnAccountBabat Babat { get; set; }
        public string Description { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
