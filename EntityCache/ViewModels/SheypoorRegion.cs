using System;
using Servicess.Interfaces;

namespace EntityCache.ViewModels
{
    public class SheypoorRegion : IHasGuid
    {
        public Guid Guid { get; set; }
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
        private string Name { get; set; }
        private Guid CityGuid { get; set; }
    }
}
