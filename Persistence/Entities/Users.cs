﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Services;
using Services.Access;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Users : Serializable<IUsers>, IUsers
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
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
    }
}
