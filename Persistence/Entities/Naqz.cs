﻿using System;
using System.ComponentModel.DataAnnotations;
using Servicess.Interfaces.Building;

namespace Persistence.Entities
{
    public class Naqz : INaqz
    {
        [Key]
        public Guid Guid { get; set; }
        public string Message { get; set; }
        public int UseCount { get; set; }
    }
}
