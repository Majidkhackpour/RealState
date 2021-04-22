using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class SerializedData : ISerializedData
    {
        [Key]
        public Guid Guid { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public string Data { get; set; }
    }
}
