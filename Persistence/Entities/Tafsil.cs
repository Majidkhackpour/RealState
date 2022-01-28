using Services;
using Services.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Tafsil : ITafsil
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Code { get; set; }
        public string Description { get; set; }
        public HesabType HesabType { get; set; }
        public DateTime DateM { get; set; }
        public decimal Account { get; set; }
        public decimal AccountFirst { get; set; }
        public bool isSystem { get; set; }
        public virtual ICollection<SanadDetail> SanadDetails { get; set; }
        public virtual ICollection<Reception> Reception { get; set; }
        public virtual ICollection<ReceptionNaqd> ReceptionNaqd { get; set; }
        public virtual ICollection<ReceptionHavale> ReceptionHavale { get; set; }
        public virtual ICollection<ReceptionCheck> ReceptionCheck { get; set; }
        public virtual ICollection<ReceptionCheckAvalDore> ReceptionCheckAvalDore_Tafsil { get; set; }
        public virtual ICollection<Pardakht> Pardakht { get; set; }
        public virtual ICollection<PardakhtHavale> PardakhtHavale { get; set; }
        public virtual ICollection<PardakhtNaqd> PardakhtNaqd { get; set; }
        public virtual ICollection<PardakhtCheckAvalDore> PardakhtCheckAvalDore { get; set; }
        public virtual ICollection<Contract> fSideContract { get; set; }
        public virtual ICollection<Contract> sSideContract { get; set; }
        public virtual ICollection<Contract> BazaryabContract { get; set; }
        public virtual ICollection<Contract> Bazaryab2Contract { get; set; }
        public virtual ICollection<BuildingRequest> BuildingRequest { get; set; }
        public virtual ICollection<CheckPage> CheckPage { get; set; }
        public virtual ICollection<PeopleBankAccount> PeopleBankAccount { get; set; }
        public virtual ICollection<PhoneBook> PhoneBook { get; set; }
        public virtual ICollection<BuildingReview> BuildingReview { get; set; }
    }
}
