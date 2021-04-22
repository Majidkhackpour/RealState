using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Settings : ISettings
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
