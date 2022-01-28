using Services;
using Servicess.Interfaces.Building;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Users : Serializable<IUsers>, IUsers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public ServerStatus ServerStatus { get; set; }
        public DateTime ServerDeliveryDate { get; set; }
        [MaxLength(400)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string UserName { get; set; }
        [MaxLength(200)]
        public string Password { get; set; }
        public EnSecurityQuestion SecurityQuestion { get; set; }
        [MaxLength(400)]
        public string AnswerQuestion { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        public string Access { get; set; }
        public virtual ICollection<Sanad> Sanad { get; set; }
        public virtual ICollection<Reception> Reception { get; set; }
        public virtual ICollection<Pardakht> Pardakht { get; set; }
        public virtual ICollection<PardakhtCheckAvalDore> PardakhtCheckAvalDore { get; set; }
        public virtual ICollection<ReceptionCheckAvalDore> ReceptionCheckAvalDore { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual ICollection<Building> Building { get; set; }
        public virtual ICollection<BuildingRequest> BuildingRequest { get; set; }
        public virtual ICollection<Note> Note { get; set; }
        public virtual ICollection<SmsLog> SmsLog { get; set; }
        public virtual ICollection<UserLog> UserLog { get; set; }
        public virtual ICollection<BuildingReview> BuildingReview { get; set; }
    }
}
