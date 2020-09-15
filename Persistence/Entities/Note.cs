using System;
using System.ComponentModel.DataAnnotations;
using PacketParser.Interfaces;
using Services;

namespace Persistence.Entities
{
    public class Note : INote
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateSabt { get; set; }
        public DateTime? DateSarresid { get; set; }
        public Guid UserGuid { get; set; }
        public EnNotePriority Priority { get; set; }
        public EnNoteStatus NoteStatus { get; set; }
    }
}
