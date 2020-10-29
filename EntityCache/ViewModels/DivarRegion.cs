﻿using System;
using Servicess.Interfaces;

namespace EntityCache.ViewModels
{
    public class DivarRegion : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
        public string Name { get; set; }
        public Guid CityGuid { get; set; }
    }
}
