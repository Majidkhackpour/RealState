using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Contract : IContract
    {
        [Key, Column(Order = 0)]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime DateM { get; set; }
        public long Code { get; set; }
        [MaxLength(100)] public string CodeInArchive { get; set; }
        [MaxLength(100)]public string RealStateCode { get; set; }
        [MaxLength(100)] public string HologramCode { get; set; }
        public bool IsTemp { get; set; }
        [ForeignKey("fTafsil"), Column(Order = 1)]
        public Guid FirstSideGuid { get; set; }
        [ForeignKey("sTafsil"), Column(Order = 2)]
        public Guid SecondSideGuid { get; set; }
        [ForeignKey("Building")]
        public Guid BuildingGuid { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        public int? Term { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal MinorPrice { get; set; }
        [MaxLength(200)] public string CheckNoTo { get; set; }
        [MaxLength(200)] public string CheckNo { get; set; }
        [MaxLength(200)] public string BankName { get; set; }
        [MaxLength(200)] public string BankNameEjare { get; set; }
        [MaxLength(200)] public string Shobe { get; set; }
        [MaxLength(100)] public string ShobeEjare { get; set; }
        public DateTime? SarResidTo { get; set; }
        public DateTime? SarResid { get; set; }
        public decimal CheckPrice1 { get; set; }
        public decimal CheckPrice2 { get; set; }
        public DateTime? DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        [MaxLength(500)] public string SetDocPlace { get; set; }
        public int SetDocNo { get; set; }
        public decimal SarQofli { get; set; }
        public decimal FirstSideDelay { get; set; }
        public decimal SecondSideDelay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        [ForeignKey("BazaryabTafsil"), Column(Order = 3)]
        public Guid? BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
        [ForeignKey("Bazaryab2Tafsil"), Column(Order = 4)]
        public Guid? Bazaryab2Guid { get; set; }
        public decimal Bazaryab2Price { get; set; }
        public long SanadNumber { get; set; }
        public EnContractBabat fBabat { get; set; }
        public EnContractBabat sBabat { get; set; }
        public decimal FirstDiscount { get; set; }
        public decimal SecondDiscount { get; set; }
        public decimal FirstTax { get; set; }
        public decimal FirstAvarez { get; set; }
        public decimal SecondTax { get; set; }
        public decimal SecondAvarez { get; set; }
        public decimal FirstTotalPrice { get; set; }
        public decimal SecondTotalPrice { get; set; }
        [MaxLength(50)] public string BuildingPlack { get; set; }
        [MaxLength(50)] public string BuildingZip { get; set; }
        [MaxLength(100)] public string SanadSerial { get; set; }
        public int PartNo { get; set; }
        public int Page { get; set; }
        [MaxLength(100)] public string Office { get; set; }
        [MaxLength(100)] public string BuildingNumber { get; set; }
        public int ParkingNo { get; set; }
        public float ParkingMasahat { get; set; }
        public int StoreNo { get; set; }
        public float StoreMasahat { get; set; }
        public int PhoneLineCount { get; set; }
        [MaxLength(50)] public string BuildingPhoneNumber { get; set; }
        public int PeopleCount { get; set; }
        [MaxLength(50)] public string PayankarNo { get; set; }
        public DateTime? PayankarDate { get; set; }
        public decimal PishPrice { get; set; }
        [MaxLength(100)] public string Witness1 { get; set; }
        [MaxLength(100)] public string Witness2 { get; set; }
        [MaxLength(100)] public string BuildingRegistrationNo { get; set; }
        [MaxLength(100)] public string BuildingRegistrationNoSub { get; set; }
        [MaxLength(100)] public string BuildingRegistrationNoOrigin { get; set; }
        [MaxLength(100)] public string BuildingCosumable { get; set; }
        [MaxLength(100)] public string ManufacturingLicensePlace { get; set; }
        public DateTime? ManufacturingLicenseDate { get; set; }
        public DateTime? SettlementDate { get; set; }
        public decimal AmountOfRent { get; set; }
        [MaxLength(100)] public string GulidType { get; set; }
        [MaxLength(100)] public string DocumentAdjust { get; set; }

        public virtual Users User { get; set; }
        [InverseProperty("fSideContract")]
        public virtual Tafsil fTafsil { get; set; }
        [InverseProperty("sSideContract")]
        public virtual Tafsil sTafsil { get; set; }
        [InverseProperty("BazaryabContract")]
        public virtual Tafsil BazaryabTafsil { get; set; }
        [InverseProperty("Bazaryab2Contract")]
        public virtual Tafsil Bazaryab2Tafsil { get; set; }
        public virtual Building Building { get; set; }
    }
}
