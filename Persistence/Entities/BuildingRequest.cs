using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class BuildingRequest : IBuildingRequest
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        [ForeignKey("Tafsil")]
        public Guid AskerGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public decimal SellPrice1 { get; set; }
        public decimal SellPrice2 { get; set; }
        public bool? HasVam { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        public short? PeopleCount { get; set; }
        public bool? HasOwner { get; set; }
        public bool? ShortDate { get; set; }
        [ForeignKey("Rental")]
        public Guid? RentalAutorityGuid { get; set; }
        [ForeignKey("City")]
        public Guid CityGuid { get; set; }
        [ForeignKey("BType")]
        public Guid BuildingTypeGuid { get; set; }
        public int Masahat1 { get; set; }
        public int Masahat2 { get; set; }
        public int RoomCount { get; set; }
        [ForeignKey("AccountType")]
        public Guid BuildingAccountTypeGuid { get; set; }
        [ForeignKey("Condition")]
        public Guid BuildingConditionGuid { get; set; }
        public string ShortDesc { get; set; }
        public virtual Tafsil Tafsil { get; set; }
        public virtual Users User { get; set; }
        public virtual RentalAuthority Rental { get; set; }
        public virtual Cities City { get; set; }
        public virtual BuildingType BType { get; set; }
        public virtual BuildingAccountType AccountType { get; set; }
        public virtual BuildingCondition Condition { get; set; }
        public virtual ICollection<BuildingRequestRegion> BuildingRequestRegion { get; set; }
    }
}
