using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services.Interfaces.Building;

namespace Persistence.Entities
{
    public class Bank : IBank
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Shobe { get; set; }
        [MaxLength(20)]
        public string CodeShobe { get; set; }
        [MaxLength(200)]
        public string HesabNumber { get; set; }
        public string Description { get; set; }
        public DateTime DateM { get; set; }
        public virtual ICollection<DasteCheck> DasteCheck { get; set; }
    }
}
