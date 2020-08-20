﻿using System.Collections.Generic;
using Services;

namespace EntityCache.ViewModels
{
    public class BuildingViewModel
    {
        public string Region { get; set; }
        public int Metrazh { get; set; }
        public string SaleSakht { get; set; }
        public string RentalAuthority { get; set; }
        public int RoomCount { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public string Tabdil { get; set; }
        public int TabaqeNo { get; set; }
        public int TabaqeCount { get; set; }
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public string Parent { get; set; }
        public EnRequestType Type { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
    }
}
