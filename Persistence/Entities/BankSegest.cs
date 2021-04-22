using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BankSegest : IBankSegest
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
    }
}
