using System;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class AdjectiveDescription : IDesc
    {
        [Key]
        public Guid Guid { get; set; }
        public string Description { get; set; }
    }
}
