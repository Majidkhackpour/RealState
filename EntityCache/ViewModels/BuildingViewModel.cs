using System;
using System.Collections.Generic;
using Services;

namespace EntityCache.ViewModels
{
    public class BuildingViewModel
    {
        public Guid Guid { get; set; }
        public string Region { get; set; }
        public int Metrazh { get; set; }
        public string SaleSakht { get; set; }
        public string RentalAuthority { get; set; }
        public string RoomCount { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public string Tabdil { get; set; }
        public string Tabaqe { get; set; }
        public string Description { get; set; }
        public List<string> Options { get; set; }
        public string Parent { get; set; }
        public EnRequestType Type { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
