﻿using System;
using System.ComponentModel.DataAnnotations;
using PacketParser;
using PacketParser.Interfaces;

namespace Persistence.Entities
{
    public class PhoneBook : IPhoneBook
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        [MaxLength(500)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Tell { get; set; }
        public EnPhoneBookGroup Group { get; set; }
        public Guid ParentGuid { get; set; }
    }
}
