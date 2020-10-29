using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class AdvToken : IAdvTokens
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public string Token { get; set; }
        public long Number { get; set; }
        public AdvertiseType Type { get; set; }
    }
}
