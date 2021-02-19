using System;
using System.ComponentModel.DataAnnotations;
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
        public Guid CheckGuid { get; set; }
        public DateTime? DatePardakht { get; set; }
        public long Number { get; set; }
        public Guid? ReceptorGuid { get; set; }
        public DateTime? DateSarresid { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public EnCheckSh CheckStatus { get; set; }
    }
}
