using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class PhoneBook : IPhoneBook
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Tell { get; set; }
        [MaxLength(200)] public string Title { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        [ForeignKey("Tafsil")]
        public Guid ParentGuid { get; set; }
        public virtual Tafsil Tafsil { get; set; }
    }
}
