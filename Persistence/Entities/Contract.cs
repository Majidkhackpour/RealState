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
        [MaxLength(200)]
        public string CheckNo { get; set; }
        [MaxLength(200)]
        public string BankName { get; set; }
        [MaxLength(200)]
        public string Shobe { get; set; }
        [MaxLength(20)]
        public string SarResid { get; set; }
        public DateTime DischargeDate { get; set; }
        public DateTime? SetDocDate { get; set; }
        [MaxLength(500)]
        public string SetDocPlace { get; set; }
        public decimal SarQofli { get; set; }
        public decimal Delay { get; set; }
        public string Description { get; set; }
        public EnRequestType Type { get; set; }
        [ForeignKey("BazaryabTafsil"), Column(Order = 3)]
        public Guid? BazaryabGuid { get; set; }
        public decimal BazaryabPrice { get; set; }
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
        public virtual Users User { get; set; }
        [InverseProperty("fSideContract")]
        public virtual Tafsil fTafsil { get; set; }
        [InverseProperty("sSideContract")]
        public virtual Tafsil sTafsil { get; set; }
        [InverseProperty("BazaryabContract")]
        public virtual Tafsil BazaryabTafsil { get; set; }
        public virtual Building Building { get; set; }
    }
}
