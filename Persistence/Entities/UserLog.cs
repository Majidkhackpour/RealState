using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class UserLog : IUserLog
    {
        [Key]
        public Guid Guid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public DateTime Date { get; set; }
        public EnLogAction Action { get; set; }
        public EnLogPart Part { get; set; }
        public string Description { get; set; }
        public virtual Users User { get; set; }
    }
}
