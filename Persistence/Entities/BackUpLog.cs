using System;
using System.ComponentModel.DataAnnotations;
using Services;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class BackUpLog : IBackUpLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime InsertedDate { get; set; }
        [MaxLength(1000)]
        public string Path { get; set; }
        public EnBackUpType Type { get; set; }
        public EnBackUpStatus BackUpStatus { get; set; }
        [MaxLength(1000)]
        public string StatusDesc { get; set; }
        public short Size { get; set; }
    }
}
