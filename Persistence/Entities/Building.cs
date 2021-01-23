using System;
using System.ComponentModel.DataAnnotations;
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
        public DateTime CreateDate { get; set; }

        [MaxLength(50)]
        public string Code { get; set; }
        public Guid OwnerGuid { get; set; }
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
        public Guid CityGuid { get; set; }
        public Guid RegionGuid { get; set; }
        public string Address { get; set; }
        public Guid BuildingConditionGuid { get; set; }
        public EnBuildingSide Side { get; set; }
        public Guid BuildingTypeGuid { get; set; }
        public string ShortDesc { get; set; }
        public Guid BuildingAccountTypeGuid { get; set; }
        public float MetrazhTejari { get; set; }
        public Guid BuildingViewGuid { get; set; }
        public Guid FloorCoverGuid { get; set; }
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
    }
}
