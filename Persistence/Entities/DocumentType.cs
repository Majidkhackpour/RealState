using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class DocumentType : IDocumentType
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
