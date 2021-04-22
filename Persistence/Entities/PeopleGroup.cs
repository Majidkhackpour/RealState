using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class PeopleGroup : IPeopleGroup
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public Guid ParentGuid { get; set; }
        public virtual ICollection<Peoples> People { get; set; }
    }
}
