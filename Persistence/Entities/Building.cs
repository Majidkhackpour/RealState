using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Building : IBuilding
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [ForeignKey("Owner")]
        public Guid OwnerGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public decimal SellPrice { get; set; }
        public decimal VamPrice { get; set; }
        public decimal QestPrice { get; set; }
        public int Dang { get; set; }
        public Guid? DocumentType { get; set; }
        public EnTarakom? Tarakom { get; set; }
        public decimal RahnPrice1 { get; set; }
        public decimal RahnPrice2 { get; set; }
        public decimal EjarePrice1 { get; set; }
        public decimal EjarePrice2 { get; set; }
        [ForeignKey("Rental")]
        public Guid? RentalAutorityGuid { get; set; }
        public bool? IsShortTime { get; set; }
        public bool? IsOwnerHere { get; set; }
        public decimal PishTotalPrice { get; set; }
        public decimal PishPrice { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string PishDesc { get; set; }
        public string MoavezeDesc { get; set; }
        public string MosharekatDesc { get; set; }
        public int Masahat { get; set; }
        public int ZirBana { get; set; }
        [ForeignKey("City")]
        public Guid CityGuid { get; set; }
        [ForeignKey("Region")]
        public Guid RegionGuid { get; set; }
        public string Address { get; set; }
        [ForeignKey("Condition")]
        public Guid BuildingConditionGuid { get; set; }
        public EnBuildingSide Side { get; set; }
        [ForeignKey("BType")]
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        [ForeignKey("AccountType")]
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        [ForeignKey("BView")]
        public Guid BuildingViewGuid { get; set; }
        [ForeignKey("FloorCover")]
        public Guid FloorCoverGuid { get; set; }
        [ForeignKey("KitchenService")]
        public Guid KitchenServiceGuid { get; set; }
        public EnKhadamati Water { get; set; }
        public EnKhadamati Barq { get; set; }
        public EnKhadamati Gas { get; set; }
        public EnKhadamati Tell { get; set; }
        public int TedadTabaqe { get; set; }
        public int TabaqeNo { get; set; }
        public int VahedPerTabaqe { get; set; }
        public float MetrazhKouche { get; set; }
        public float ErtefaSaqf { get; set; }
        public float Hashie { get; set; }
        [MaxLength(30)]
        public string SaleSakht { get; set; }
        [MaxLength(30)]
        public string DateParvane { get; set; }
        [MaxLength(200)]
        public string ParvaneSerial { get; set; }
        public bool BonBast { get; set; }
        public bool MamarJoda { get; set; }
        public int RoomCount { get; set; }
        public EnBuildingPriority Priority { get; set; }
        public bool IsArchive { get; set; }
        [MaxLength(100)]
        public string Image { get; set; }
        public virtual Peoples Owner { get; set; }
        public virtual Users User { get; set; }
        public virtual RentalAuthority Rental { get; set; }
        public virtual Cities City { get; set; }
        public virtual Regions Region { get; set; }
        public virtual BuildingCondition Condition { get; set; }
        public virtual BuildingType BType { get; set; }
        public virtual BuildingAccountType AccountType { get; set; }
        public virtual BuildingView BView { get; set; }
        public virtual FloorCover FloorCover { get; set; }
        public virtual KitchenService KitchenService { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<BuildingGallery> BuildingGallery { get; set; }
        public virtual ICollection<BuildingMedia> BuildingMedia { get; set; }
        public virtual ICollection<BuildingRelatedOptions> BuildingRelatedOptions { get; set; }
    }
}
