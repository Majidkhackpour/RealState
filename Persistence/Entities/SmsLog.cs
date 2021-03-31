﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class SmsLog : ISmsLog
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("User")]
        public Guid UserGuid { get; set; }
        [MaxLength(200)]
        public string Sender { get; set; }
        [MaxLength(200)]
        public string Reciver { get; set; }
        public string Message { get; set; }
        public decimal Cost { get; set; }
        public long MessageId { get; set; }
        [MaxLength(50)]
        public string StatusText { get; set; }
        public virtual Users User { get; set; }
    }
}
