using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Peoples : IPeoples
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string NationalCode { get; set; }
        [MaxLength(20)]
        public string IdCode { get; set; }
        [MaxLength(200)]
        public string FatherName { get; set; }
        [MaxLength(500)]
        public string PlaceBirth { get; set; }
        [MaxLength(20)]
        public string DateBirth { get; set; }
        public string Address { get; set; }
        [MaxLength(200)]
        public string IssuedFrom { get; set; }
        [MaxLength(50)]
        public string PostalCode { get; set; }
        [ForeignKey("Group")]
        public Guid GroupGuid { get; set; }
        public virtual PeopleGroup Group { get; set; }
        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<PhoneBook> PhoneBook { get; set; }
    }
}
