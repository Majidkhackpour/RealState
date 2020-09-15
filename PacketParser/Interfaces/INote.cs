using System;
using Services;

namespace PacketParser.Interfaces
{
    public interface INote : IHasGuid
    {
        string Title { get; set; }
        string Description { get; set; }
        DateTime DateSabt { get; set; }
        DateTime? DateSarresid { get; set; }
        Guid UserGuid { get; set; }
        EnNotePriority Priority { get; set; }
        EnNoteStatus NoteStatus { get; set; }
    }
}
